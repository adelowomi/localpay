using System.Net;
using System.Net.Http;
using LocalPay.Flutterwave;
using LocalPay.Flutterwave.Models;
using LocalPay.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Options;
using Refit;
using RichardSzalay.MockHttp;

namespace LocalPay.Tests;

public class FlutterwaveServiceTests
{
    [Fact]
    public async Task ValidatePayment_hits_verify_endpoint_with_long_id()
    {
        var (payments, mock) = BuildClient(handler =>
        {
            handler.When(HttpMethod.Get, "https://api.flutterwave.com/v3/transactions/4368404/verify")
                .Respond("application/json", """
                {
                  "status": "success",
                  "message": "ok",
                  "data": { "id": 4368404, "tx_ref": "tx-1", "amount": 100, "currency": "NGN",
                            "charged_amount": 100, "app_fee": 1.4, "merchant_fee": 0,
                            "status": "successful", "payment_type": "card",
                            "created_at": "2024-01-01T00:00:00Z", "account_id": 1, "amount_settled": 98.6 }
                }
                """);
        });

        var resp = await payments.ValidatePayment(4368404L);

        resp.Status.Should().Be("success");
        resp.Data!.Id.Should().Be(4368404L);
        mock.VerifyNoOutstandingExpectation();
    }

    [Fact]
    public async Task GetBanks_sends_country_in_path()
    {
        var (payments, mock) = BuildClient(handler =>
        {
            handler.When(HttpMethod.Get, "https://api.flutterwave.com/v3/banks/NG")
                .Respond("application/json", """
                { "status": "success", "message": "ok", "data": [ { "id": 1, "code": "044", "name": "Access" } ] }
                """);
        });

        var banks = await payments.GetBanks("NG");

        banks.Data.Should().HaveCount(1);
        banks.Data[0].Code.Should().Be("044");
    }

    [Fact]
    public async Task InitiatePayment_posts_snake_case_body_and_returns_link()
    {
        string? capturedBody = null;
        var (payments, mock) = BuildClient(handler =>
        {
            handler.When(HttpMethod.Post, "https://api.flutterwave.com/v3/payments")
                .With(req =>
                {
                    capturedBody = req.Content?.ReadAsStringAsync().GetAwaiter().GetResult();
                    return true;
                })
                .Respond("application/json", """
                { "status": "success", "message": "Hosted Link", "data": { "link": "https://checkout.flutterwave.com/v3/hosted/pay/abc" } }
                """);
        });

        var resp = await payments.InitiatePayment(new PaymentPayload
        {
            TxRef = "tx-99",
            Amount = 250m,
            Currency = "NGN",
            RedirectUrl = "https://x.test/return",
            Customer = new Customer { Email = "a@b.com", Name = "Q" }
        });

        resp.Data!.Link.Should().StartWith("https://checkout.flutterwave.com/");
        capturedBody.Should().Contain("\"tx_ref\":\"tx-99\"")
                    .And.Contain("\"amount\":250")
                    .And.Contain("\"redirect_url\":\"https://x.test/return\"");
    }

    [Fact]
    public async Task ApiError_surfaces_as_ApiException()
    {
        var (payments, _) = BuildClient(handler =>
        {
            handler.When(HttpMethod.Get, "https://api.flutterwave.com/v3/transactions/1/verify")
                .Respond(HttpStatusCode.Unauthorized, "application/json", """{ "status": "error", "message": "Unauthorized" }""");
        });

        Func<Task> act = () => payments.ValidatePayment(1L);

        await act.Should().ThrowAsync<ApiException>();
    }

    [Fact]
    public async Task CancellationToken_is_observed()
    {
        var (payments, _) = BuildClient(handler =>
        {
            handler.When(HttpMethod.Get, "*").Respond(async () =>
            {
                await Task.Delay(5_000);
                return new HttpResponseMessage(HttpStatusCode.OK);
            });
        });

        using var cts = new CancellationTokenSource();
        cts.Cancel();

        Func<Task> act = () => payments.GetBanks("NG", cts.Token);

        await act.Should().ThrowAsync<TaskCanceledException>();
    }

    private static (IFlutterwavePayments payments, MockHttpMessageHandler handler) BuildClient(Action<MockHttpMessageHandler> setup)
    {
        var mock = new MockHttpMessageHandler();
        setup(mock);

        var services = new ServiceCollection();
        services.AddSingleton(new FlutterwaveInitializationPayload { SecretKey = "FLWSECK_TEST-xxxx" });

        var refitSettings = new RefitSettings { ContentSerializer = new NewtonsoftJsonContentSerializer() };

        services
            .AddRefitClient<IFlutterwaveService>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.flutterwave.com/v3"))
            .ConfigurePrimaryHttpMessageHandler(() => mock);

        services.AddScoped<IFlutterwavePayments, FlutterwavePayments>();

        var provider = services.BuildServiceProvider();
        var payments = provider.GetRequiredService<IFlutterwavePayments>();
        return (payments, mock);
    }
}
