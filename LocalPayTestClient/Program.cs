
using LocalPay.Baxi;
using LocalPay.Extensions;
using LocalPayTestClient.Services;
using LocalPayTestClient.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models.InitializationModels;

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// var serviceProvider = new ServiceCollection().
//         AddTransient<IBaxiPayments, BaxiPayments>();


class Program
{ 
        static void Main(string[] args)
        {
                var host = CreateHostBuilder(args).Build();
                host.Services.GetService<ITestService>().InitiateTest();
                Console.Read();

        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                        services.AddBaxi(new BaxiInitializationPayload(){ 
                        APIKey="5adea9-044a85-708016-7ae662-646d59",
                        UserName = "baxi_test",
                        UserSecret ="5xjqQ7MafFJ5XBTN"
                        });
                        services.AddScoped<ITestService,TestService>();
                });
        

}

