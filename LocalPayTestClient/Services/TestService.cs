using LocalPay.Baxi;
using LocalPayTestClient.Services.Abstraction;

namespace LocalPayTestClient.Services
{
    public class TestService : ITestService
    {

        private readonly IBaxiPayments _baxiService;

        public TestService(IBaxiPayments baxiService)
        {
            _baxiService = baxiService;
        }

        public void InitiateTest()
        {
           GetBalance();   
           GetBillerCategory(); 
           GetBaxiProviders();
           GetBillerByCategory();
           GetBouquetAddons();
           GetDataBundleServiceProviders();
           GetElectricityBillers();
           GetEpinBundles();
           GetEpinProviders();
           GetJambProducts();
           GetJambProviders();
           GetProviderBouquets();
           GetProviderBundles();
           PurchaseAirtime();
           PurchaseDataBundle();
           PurchaseEpin();
           PurchaseJambProduct();
           PurchasePostPaidElectricity();
           PurchasePrePaidElectricity();
           ChangeCableSubscriptionBody();
           AccountValidation();
           JambAccountValidation();
           SubscriptionRenewal();
           MultichoiceAccountValidation();
           Console.WriteLine("If this shows up, the test service is working!");
        }

        private void GetBalance()
        {
            var balance = _baxiService.GetBalance().Result;
            Console.WriteLine("Balance: " + balance.Data.Balance);
        }

        private void GetBillerCategory()
        {
            var billerCategory = _baxiService.GetBillerCategory().Result;
            Console.WriteLine("Biller Category: " + billerCategory.Data[0].Name);
        }

        private void GetBillerByCategory()
        {
            var biller = _baxiService.GetBillerByCategory("airtime").Result;
            Console.WriteLine("Biller" + biller.Data[0].id);
        }

        private void GetBaxiProviders()
        {
            var providers = _baxiService.GetBaxiProviders().Result;
            Console.WriteLine("Baxi Providers: " + providers.Data.Providers[0].Name);
        }

        private void PurchaseAirtime()
        {
            var airtime = new AirtimeBody
            {
                Plan = "prepaid",
                Amount = 100,
                AgentReference = "12",
                serviceType = "mtn",
                Phone = "08000000000000",
                AgentId = "081"
            };
            var airtimeResponse = _baxiService.PurchaseAirtime(airtime).Result;
            Console.WriteLine("Airtime Response: " + airtimeResponse.Data.StatusCode);

        }

        private void GetDataBundleServiceProviders()
        {
            _baxiService.GetDataBundleServiceProviders().Result; 
        }

        private void GetProviderBundles()
        {
            var providerBundle = new ProviderBundleBody
            {
                ServiceType = "mtn"
            };
            var providerBundleResponse = _baxiService.GetProviderBundles(providerBundle).Result;
            Console.WriteLine("Provider Bundle Response: " + providerBundleResponse.Data[0].DataCode);
        }

        private void PurchaseDataBundle()
        {
            var dataBundle = new DataBundleBody
            {
                Plan = "prepaid",
                Amount = 1000,
                AgentReference = "123",
                serviceType = "mtn",
                Phone = "08000000000000"
                AgentId = "08067",
                DataCode = "1000",

            };
            var dataBundleResponse = _baxiService.PurchaseDataBundle(dataBundle).Result;
            Console.WriteLine("Data Bundle Response: " + dataBundleResponse.Data.StatusCode);
        }

        private void MultichoiceAccountValidation()
        {
            var providerBundle = new ProviderBundleBody
            {
                ServiceType = "dstv",
                AccountNumber = "4131953321"
            };
            var providerBundleResponse = _baxiService.MultichoiceAccountValidation(providerBundle).Result;
            Console.WriteLine("Multichoice Account Validation Response: " + providerBundleResponse.Data.User.Name);
        }

        private void SubscriptionRenewal()
        {
                var subscription = new SubscriptionBody
                {
                    TotalAmount = 2000,
                    ProductMonthsPaidFor = "1",
                    ProductCode="0",
                    ServiceType = "dstv",
                    AgentId = "08012",
                    AgentReference = "1234",
                    SmartcardNumber = "4131953321"

                };
                var subscriptionResponse = _baxiService.SubscriptionRenewal(subscription).Result;
                Console.WriteLine("Subscription Renewal Response: " + subscriptionResponse.Data.StatusCode);
        }

       private void GetProviderBouquets()
        {
            var providerBouquet = _baxiService.GetProviderBouquets("dstv").Result;
            Console.WriteLine("Provider Bouquets: " + provideBouquet[0].Data[0].Name);
        }

        private void GetBouquetAddons()
        {
            var bouquet = new BouquetBody
            {
                ServiceType = "dstv",
                ProductCode = "ASIADDE36"
            };
            var List<bouquetResponse> = _baxiService.GetBouquetAddons(bouquet).Result;
            Console.WriteLine("Bouquet Addons: " + bouquetResponse[0].Data[0].Name);
        }

        private void ChangeCableTvSubscription()
        {
            vary cableSubscription = new CableSubscriptionBody
            {
                ServiceType = "dstv",
                ProductCode = "ASIADDE36",
                ProductMonthsPaidFor = "1",
                AgentId = "08056",
                AgentReference = "12345",
                SmartcardNumber = "4131953321",
                TotalAmount = 5050,
                AddonMonthsPaidFor = "1"
            };
            var cableSubscriptionResponse = _baxiService.ChangeCableTvSubscription(cableSubscription).Result;
            Console.WriteLine("Change Cable Tv Subscription Response: " + cableSubscriptionResponse.Data.StatusCode);

        }

        private void GetEpinProviders()
        {
            var epinProviders = _baxiService.GetEpinProviders().Result;
            Console.WriteLine("Epin Providers: " + epinProviders.Data.Providers[0].Name);
        }

       private void GetEpinBundles()
        {
            var epinBouquets = _baxiService.GetEpinBundles("glo").Result;
            Console.WriteLine("Epin Bouquets: " + epinBouquets.Data[0].amount);
        }

        private void PurchaseEpin()
        {
            var epin = new Epin
            {
                ServiceType = "glo",
                PinValue = "50",
                NumberOfPins = "1",
                AgentId = "0800",
                AgentReference = "123456",
                Amount = 50,
            };
            var epinResponse = _baxiService.PurchaseEpin(epin).Result;
            Console.WriteLine("Purchase Epin Response: " + epinResponse.Data.StatusCode);
        }

        private void JambAccountValidation()
        {
            var jambCustomer = new JambCustomerBody
            {
                ServiceType = "jamb",
                AccountNumber = "9678528341",
                ProductCode = "DE"
            };
            var jambCustomerResponse = _baxiService.AccountValidation(jambCustomer).Result;
            Console.WriteLine("Account Validation Response: " + jambCustomerResponse.Data.User.Name);
        }

        private void GetJambProducts()
        {
            var jambProviders = _baxiService.GetJambProviders("jamb").Result;
            Console.WriteLine("Jamb Providers: " + jambProviders.Data[0].Id);
        }

        private void PurchaseJambProduct()
        {
            var jambProduct = new JambProductBody
            {
                ServiceType = "jamb",
                AccountNumber = "9678528341",
                ProductCode = "DE",
                Phonenumber = "08000000000000",
                AgentReference = "1234567",
                Amount = 4000
            };
            var jambProductResponse = _baxiService.PurchaseJambProduct(jambProduct).Result;
            Console.WriteLine("Purchase Jamb Product Response: " + jambProductResponse.Data.ProviderStatusCode);
        }

        private void GetElectricityBillers()
        {
            var electricityBillers = _baxiService.GetElectricityBillers().Result;
            Console.WriteLine("Electricity Billers: " + electricityBillers.Data[0].Name);
        }

        private void AccountValidation()
        {
            var providerBundle = new providerBundleBody
            {
                ServiceType = "jamb",
                AccountNumber = "9678528341",
            };
            var providerBundleResponse = _baxiService.AccountValidation(providerBundle).Result;
            Console.WriteLine("Account Validation Response: " + providerBundleResponse.Data.User.Name);
        }

       private void PurchasePostPaidElectricity()
        {
            var electricity = new ElectricityBody
            {
                ServiceType = "ikeja_electric_postpaid",
                AccountNumber = "04042404139",
                Phonenumber = "08000000000000",
                AgentReference = "12345678",
                Amount = 1000,
                AgentId = "1230"
            };
            var electricityResponse = _baxiService.PurchasePostPaidElectricity(electricity).Result;
            Console.WriteLine("Purchase Post Paid Electricity Response: " + electricityResponse.Data.StatusCode);
        }

        private void PurchasePrePaidElectricity()
        {
            var electricity = new ElectricityBody
            {
                ServiceType = "ikeja_electric_prepaid",
                AccountNumber = "04042404048",
                Phonenumber = "08000000000000",
                AgentReference = "1234568",
                Amount = 1000,
                AgentId = "12301"
            };
            var electricityResponse = _baxiService.PurchasePrePaidElectricity(electricity).Result;
            Console.WriteLine("Purchase Pre Paid Electricity Response: " + electricityResponse.Data.StatusCode);
        }
        

    }
}