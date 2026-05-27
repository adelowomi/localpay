using System;
using System.Net.Http.Headers;
using LocalPay.Baxi;
using LocalPay.Flutterwave;
using LocalPay.Flutterwave.Models;
using LocalPay.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models.InitializationModels;
using Refit;

namespace LocalPay.Extensions
{
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Register the Baxi client. Preserves the legacy (pre-2.0) wiring.
        /// Note: Baxi auth is moving to HMAC-SHA1 request signing; this registration
        /// will be revised in a follow-up release. See the project README for status.
        /// </summary>
        public static IServiceCollection AddBaxi(this IServiceCollection services, BaxiInitializationPayload options)
        {
            if (options is null) throw new ArgumentNullException(nameof(options));
            services.AddSingleton(options);
            services.AddScoped<IBaxiPayments, BaxiPayments>();
            return services;
        }

        /// <summary>
        /// Register the Flutterwave client. Uses <see cref="System.Net.Http.IHttpClientFactory"/>
        /// under the hood for connection pooling and timeout/retry policies.
        /// </summary>
        /// <param name="services">DI container.</param>
        /// <param name="options">Configuration — at minimum, your <c>SecretKey</c>.</param>
        public static IServiceCollection AddFlutterwave(this IServiceCollection services, FlutterwaveInitializationPayload options)
        {
            if (options is null) throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(options.SecretKey))
                throw new ArgumentException("SecretKey is required.", nameof(options));

            services.AddSingleton(options);

            var refitSettings = new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer()
            };

            services
                .AddRefitClient<IFlutterwaveService>(refitSettings)
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(options.BaseUrl);
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", options.SecretKey);
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("LocalPay/2.0 (+https://github.com/adelowomi/localpay)");
                });

            services.AddScoped<IFlutterwavePayments, FlutterwavePayments>();
            return services;
        }
    }
}
