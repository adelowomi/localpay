# Changelog

All notable changes to this project are documented here. The format follows
[Keep a Changelog](https://keepachangelog.com/en/1.1.0/) and this project
adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [2.0.0]

### Breaking changes — Flutterwave

- **Transaction, transfer, and account IDs are now `long`** (previously `int`).
  Real Flutterwave IDs can exceed `Int32` range; `int` silently truncates and
  produces wrong values at the wire. Callers must update parameter and field
  types where they store these.
- **Monetary amounts are now `decimal`** (previously `int` for amounts and
  `string` for `PaymentPayload.Amount`). Avoids dropping kobo precision on
  amounts such as `1500.50`.
- **All public methods accept an optional `CancellationToken`**.
- **All Flutterwave model properties are PascalCase** with explicit
  `[JsonProperty("snake_case")]` mappings to the wire format. Fixes a latent
  bug where `TransferResponse` PascalCase fields could not deserialize
  Flutterwave's snake_case response bodies.
- `PaymentResponseData.Status` and `TransferResponseData.Status` renamed to
  `TransactionStatus` and `TransferStatus` respectively to avoid colliding
  with the envelope's `Status`.
- `Customer.phoneNumber` is now serialized as `phonenumber` to match the
  Flutterwave wire contract (this is what the API actually expects).

### Added

- `IFlutterwavePayments.RefundTransaction(long transactionId, RefundPayload, CancellationToken)`
  for full and partial refunds.
- `FlutterwaveWebhook.Verify(...)` — static helper that verifies both the
  legacy `verif-hash` (plain equality) and the newer `flutterwave-signature`
  (HMAC-SHA256) headers. Uses constant-time comparison.
- `FlutterwaveInitializationPayload.BaseUrl` (defaults to v3 production) and
  `WebhookSecretHash` for the verifier.

### Changed

- `FlutterwavePayments` no longer constructs its own `HttpClient`. The Refit
  client is now registered via `AddRefitClient<IFlutterwaveService>()` inside
  `AddFlutterwave`, backed by `IHttpClientFactory`. Eliminates socket
  exhaustion and lets consumers compose Polly handlers.
- Bumped `Refit` 6.3.2 → 8.0.0 (with `Refit.HttpClientFactory` and
  `Refit.Newtonsoft.Json` for serializer compatibility with the legacy Baxi
  models).
- Added `Microsoft.Extensions.Http`, `Microsoft.Extensions.Options` 8.0.
- Multi-target `netstandard2.0;net8.0` (was `netstandard2.0` only).
- Source Link via `Microsoft.SourceLink.GitHub` for step-into debugging.
- XML documentation generation enabled; `LangVersion` set to `latest`.

### Repository hygiene

- Added `.gitignore`, `LICENSE` (MIT), and `.editorconfig`.
- Removed accidentally-committed build artifacts: `.vs/`, `.vscode/`, `bin/`,
  `obj/`, `.DS_Store`, and old `.nupkg` files.

### CI / release

- New `ci.yml` GitHub Actions workflow: restore, build, test on every
  push and PR.
- New `release.yml` workflow: on `v*.*.*` tags, pack and push to nuget.org,
  then create a GitHub release with the artifacts attached. Requires
  `NUGET_API_KEY` secret.

### Removed

- `LocalPayTestClient` project deleted. It targeted out-of-support `net6.0`,
  was a console runner rather than real tests, and had committed live API
  credentials. Replaced by the `LocalPay.Tests` xUnit project.

### Security

- Hardcoded API keys (Baxi `APIKey`, `UserName`, `UserSecret`, plus a
  Flutterwave `FLWSECK_TEST-` key) were committed in `LocalPayTestClient`
  since 2022. They have been removed in this release. **Rotate any of those
  keys that are still in use.**

### Baxi — deferred

Baxi is **untouched in this release**. Research indicates Baxi has migrated to
HMAC-SHA1 request signing (separate `API_KEY` + `USER_SECRET`), but the exact
header names and several endpoint paths could not be verified against the
live documentation. A Baxi 2.0 rewrite will land in a follow-up release once
the auth spec is confirmed against a working integration.

## [1.0.6] — 2023

Last release of the v1 line. Baseline before modernization.
