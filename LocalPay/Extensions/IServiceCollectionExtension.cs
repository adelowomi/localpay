using LocalPay.Baxi;
using LocalPay.Flutterwave;
using Microsoft.Extensions.DependencyInjection;
using Models.InitializationModels;

namespace LocalPay.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddBaxi(this IServiceCollection services, BaxiInitializationPayload options)
        {
            services.AddSingleton(options);
            services.AddScoped<IBaxiPayments, BaxiPayments>();
            return services;
        }

        public static IServiceCollection AddFlutterwave(this IServiceCollection services, Flutterwave.Models.FlutterwaveInitializationPayload options)
        {
            services.AddSingleton(options);
            services.AddScoped<IFlutterwavePayments, FlutterwavePayments>();
            return services;
        }
    }
}