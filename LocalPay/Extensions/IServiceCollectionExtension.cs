using LocalPay.Baxi;
using Microsoft.Extensions.DependencyInjection;
using Models.InitializationModels;

namespace LocalPay.Extensions
{
    public  static class IServiceCollectionExtension
    {
        public static IServiceCollection AddBaxi(this IServiceCollection services,BaxiInitializationPayload options)
        {
            services.AddSingleton(options);
            services.AddScoped<IBaxiPayments, BaxiPayments>();
            return services;
        }
    }
}