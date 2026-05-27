# LocalPay

[![NuGet](https://img.shields.io/nuget/v/LocalPay.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/LocalPay)
[![CI](https://github.com/adelowomi/localpay/actions/workflows/ci.yml/badge.svg)](https://github.com/adelowomi/localpay/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=flat-square)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-net8.0%20%7C%20netstandard2.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)

A .NET SDK that unifies multiple Nigerian payment and utility providers behind a single, strongly-typed, DI-friendly API surface. Built on `IHttpClientFactory` and [Refit](https://github.com/reactiveui/refit).

| Provider     | Status (v2.0) | Notes                                                      |
| ------------ | ------------- | ---------------------------------------------------------- |
| Flutterwave  | **Stable**    | v3 REST API. Long-typed IDs, decimal amounts, refunds, webhook verification helper. |
| Baxi         | Carried over  | Legacy v1 surface preserved as-is. Modern rewrite tracked under "Roadmap" below. |

## Install

```bash
dotnet add package LocalPay
```

LocalPay targets **`net8.0`** and **`netstandard2.0`**, so it works in .NET 6+, .NET Framework 4.6.1+ (via netstandard), and anywhere `IHttpClientFactory` is available.

## Quick start — Flutterwave

```csharp
using LocalPay.Extensions;
using LocalPay.Flutterwave.Models;

// 1. Register with DI
builder.Services.AddFlutterwave(new FlutterwaveInitializationPayload
{
    SecretKey         = builder.Configuration["Flutterwave:SecretKey"]!,
    WebhookSecretHash = builder.Configuration["Flutterwave:WebhookSecretHash"]
});

// 2. Inject IFlutterwavePayments anywhere
public class CheckoutService(IFlutterwavePayments flutterwave)
{
    public async Task<string> StartHostedCheckout(decimal amount, string email, CancellationToken ct)
    {
        var resp = await flutterwave.InitiatePayment(new PaymentPayload
        {
            TxRef        = Guid.NewGuid().ToString("N"),
            Amount       = amount,
            Currency     = "NGN",
            RedirectUrl  = "https://your-app.com/payments/return",
            Customer     = new Customer { Email = email, Name = "Customer" },
            Customizations = new Customization { Title = "Order #1234" }
        }, ct);

        return resp.Data!.Link;
    }
}
```

### Verifying a webhook

```csharp
[HttpPost("/webhooks/flutterwave")]
public async Task<IActionResult> Handle(
    [FromServices] FlutterwaveInitializationPayload opts,
    CancellationToken ct)
{
    Request.EnableBuffering();
    using var ms = new MemoryStream();
    await Request.Body.CopyToAsync(ms, ct);
    var raw = ms.ToArray();

    var ok = FlutterwaveWebhook.Verify(
        secretHash:             opts.WebhookSecretHash!,
        rawRequestBody:         raw,
        signatureHeaderValue:   Request.Headers[FlutterwaveWebhook.SignatureHeader],
        legacyHashHeaderValue:  Request.Headers[FlutterwaveWebhook.LegacySignatureHeader]);

    if (!ok) return Unauthorized();

    // ... process the verified event
    return Ok();
}
```

## Flutterwave surface

All methods accept an optional `CancellationToken`.

| Method                              | Endpoint                                | Purpose                                 |
| ----------------------------------- | --------------------------------------- | --------------------------------------- |
| `InitiatePayment(PaymentPayload)`   | `POST /payments`                        | Standard hosted-checkout session        |
| `InitiateTokenizedPayment(...)`     | `POST /tokenized-charges`               | Charge a saved card token               |
| `ValidatePayment(long id)`          | `GET  /transactions/{id}/verify`        | Verify a transaction                    |
| `RefundTransaction(long id, ...)`   | `POST /transactions/{id}/refund`        | Full or partial refund                  |
| `InitiateNgnTransfer(...)`          | `POST /transfers`                       | Domestic NGN bank transfer              |
| `GetTransfer(long id)`              | `GET  /transfers/{id}`                  | Fetch transfer by id                    |
| `GetBanks(string country)`          | `GET  /banks/{country}`                 | List banks for an ISO country code      |

## Configuration

| Option              | Default                              | Description                                  |
| ------------------- | ------------------------------------ | -------------------------------------------- |
| `SecretKey`         | _required_                           | Your Flutterwave secret key                  |
| `BaseUrl`           | `https://api.flutterwave.com/v3`     | Override for sandbox or future v4 migration  |
| `WebhookSecretHash` | _optional_                           | Required only if you use `FlutterwaveWebhook.Verify` |

You can plug Polly resilience policies onto the Refit client by reaching the same HttpClient name Refit registers:

```csharp
builder.Services
    .AddHttpClient<IFlutterwaveService>()
    .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, retry => TimeSpan.FromSeconds(Math.Pow(2, retry))));
```

## Migrating from v1.x

`v2.0` is a breaking release on the Flutterwave surface. The high-impact changes:

- Transaction / transfer / account `Id` fields are now `long` instead of `int`.
- Money fields are `decimal` instead of `int` or `string`.
- All model properties are PascalCase (the wire format is still snake_case, mapped via `[JsonProperty]`).
- `PaymentResponseData.Status` → `TransactionStatus`. `TransferResponseData.Status` → `TransferStatus`.

See the [CHANGELOG](CHANGELOG.md) for the full list.

## Roadmap

- **Baxi 2.0** — verify HMAC-SHA1 request signing against the live developer portal, replace the legacy `Authorization: Api-key` header, refresh endpoint paths against the current B2B documentation, add a transaction re-query path, and add a webhook receiver helper. Tracked separately because the spec needs first-hand verification.
- **Flutterwave v4** — once v4 reaches GA and Flutterwave publishes a v3 sunset date, add a v4 client behind an `ApiVersion` switch. v3 is still recommended at the time of writing.
- **Virtual accounts, bills, transfer rates, beneficiaries** — Flutterwave v3 exposes these and the SDK does not. Slated for `2.1`.

## Development

```bash
git clone https://github.com/adelowomi/localpay.git
cd localpay
dotnet restore
dotnet build -c Release
dotnet test
```

The test suite covers DI registration, model (de)serialization against real Flutterwave example payloads, webhook signature verification (both schemes), and a full Refit-over-mock-HTTP integration on the public methods.

## Contributing

Pull requests are welcome. For non-trivial changes, please open an issue first to discuss the approach.

1. Fork the repo and create a topic branch off `master`.
2. Make your change with tests.
3. Make sure `dotnet test` is green.
4. Submit the PR with a short description and motivation.

## License

[MIT](LICENSE) — Copyright (c) Adelowo Ajibola.
