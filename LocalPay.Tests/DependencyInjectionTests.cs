using System;
using LocalPay.Extensions;
using LocalPay.Flutterwave;
using LocalPay.Flutterwave.Models;
using LocalPay.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LocalPay.Tests;

public class DependencyInjectionTests
{
    [Fact]
    public void AddFlutterwave_registers_payments_and_refit_service()
    {
        var services = new ServiceCollection();
        services.AddFlutterwave(new FlutterwaveInitializationPayload { SecretKey = "FLWSECK_TEST-xxxx" });

        var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        scope.ServiceProvider.GetService<IFlutterwavePayments>().Should().NotBeNull();
        scope.ServiceProvider.GetService<IFlutterwaveService>().Should().NotBeNull();
        scope.ServiceProvider.GetService<FlutterwaveInitializationPayload>().Should().NotBeNull();
    }

    [Fact]
    public void AddFlutterwave_throws_when_options_null()
    {
        var services = new ServiceCollection();
        Action act = () => services.AddFlutterwave(null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AddFlutterwave_throws_when_secret_key_missing()
    {
        var services = new ServiceCollection();
        Action act = () => services.AddFlutterwave(new FlutterwaveInitializationPayload { SecretKey = "" });
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AddFlutterwave_resolves_independent_payments_per_scope()
    {
        var services = new ServiceCollection();
        services.AddFlutterwave(new FlutterwaveInitializationPayload { SecretKey = "FLWSECK_TEST-xxxx" });
        var provider = services.BuildServiceProvider();

        using var scopeA = provider.CreateScope();
        using var scopeB = provider.CreateScope();

        var paymentsA = scopeA.ServiceProvider.GetRequiredService<IFlutterwavePayments>();
        var paymentsB = scopeB.ServiceProvider.GetRequiredService<IFlutterwavePayments>();

        paymentsA.Should().NotBeSameAs(paymentsB);
    }
}
