using LocalPay.Baxi;
using LocalPay.Models.ViewModels.Baxi;
using LocalPayTestClient.Services.Abstraction;


namespace LocalPayTestClient.Services
{
    public class BaxiTestService : IBaxiTestService
    {

        private readonly IBaxiPayments _baxiService;

        public BaxiTestService(IBaxiPayments baxiService)
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
            //GetJambProducts();//method not allowed
            GetProviderBouquets();
            JambAccountValidation();
            GetProviderBundles();
            PurchaseAirtime();
            PurchaseDataBundle();
            PurchaseSpectranetDataBundle();
            PurchaseEpin();
            //PurchaseJambProduct(); //500
            PurchasePostPaidElectricity();
            PurchasePrePaidElectricity();
            ChangeCableTvSubscription();
            ElectricityAccountValidation();

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
            var serviceType = new ServiceBody()
            {
                ServiceType = "epin"
            };
            var biller = _baxiService.GetBillerByCategory(serviceType).Result;
            Console.WriteLine("Biller: " + biller.Data[0].ServiceCategory);
        }

        private void GetBaxiProviders()
        {
            var providers = _baxiService.GetBaxiProviders().Result;
            Console.WriteLine("Baxi Providers: " + providers.Data.Providers[0].Name);
        }

        private void PurchaseAirtime()
        {
            Random rd = new Random();
            var airtime = new AirtimeBody
            {
                Plan = "prepaid",
                Amount = 100,
                AgentReference = RandomNumber(),
                ServiceType = "mtn",
                Phone = "07035361770",
                AgentId = RandomNumber()
            };
            var airtimeResponse = _baxiService.PurchaseAirtime(airtime).Result;
            Console.WriteLine("Airtime Response: " + airtimeResponse.Data.StatusCode);

        }

        private void GetDataBundleServiceProviders()
        {
            var dataBundle = _baxiService.GetDataBundleServiceProviders().Result;
            Console.WriteLine("Data Bundle Providers: " + dataBundle.Data.Providers[0].Name);
        }

        private void GetProviderBundles()
        {
            var providerBundle = new ProviderBundleBody
            {
                ServiceType = "mtn"
            };
            var providerBundleResponse = _baxiService.GetProviderBundles(providerBundle).Result;
            Console.WriteLine("Provider Bundle Response: " + providerBundleResponse.Data[0].Datacode);
        }

        private void PurchaseDataBundle()
        {
            var dataBundle = new DataBundleBody
            {
                Plan = "prepaid",
                Amount = 100,
                AgentReference = RandomNumber(),
                ServiceType = "mtn",
                Phone = "07035361770",
                AgentId = RandomNumber(),
                DataCode = "100"
            };
            var dataBundleResponse = _baxiService.PurchaseDataBundle(dataBundle).Result;
            Console.WriteLine("Data Bundle Response: " + dataBundleResponse.Data.StatusCode);
        }

        private void PurchaseSpectranetDataBundle()
        {
            var dataBundle = new SpectranetBody
            {
                Plan = "prepaid",
                Amount = 5000,
                AgentReference = RandomNumber(),
                ServiceType = "spectranet",
                Phone = "210001245",
                AgentId = RandomNumber(),
                DataCode = "43456",
                Package = "CHANGE_IMMEDIATE"
            };
            var dataBundleResponse = _baxiService.PurchaseDataBundle(dataBundle).Result;
            Console.WriteLine("Data Spectranet Bundle Response: " + dataBundleResponse.Data.StatusCode);
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
                TotalAmount = "2000",
                ProductMonthsPaidFor = "1",
                ProductCode = "0",
                ServiceType = "dstv",
                AgentId = RandomNumber(),
                AgentReference = RandomNumber(),
                SmartcardNumber = "4131953321"

            };
            var subscriptionResponse = _baxiService.SubscriptionRenewal(subscription).Result;
            Console.WriteLine("Subscription Renewal Response: " + subscriptionResponse.Data.StatusCode);
        }

        private void GetProviderBouquets()
        {
            var serviceType = new ServiceBody()
            {
                ServiceType = "dstv"
            };
            var providerBouquet = _baxiService.GetProviderBouquets(serviceType).Result;
            Console.WriteLine("Provider Bouquets: " + providerBouquet.Data[0].Name);
        }

        private void GetBouquetAddons()
        {
            var bouquet = new BouquetBody
            {
                ServiceType = "dstv",
                ProductCode = "ASIADDE36"
            };
            var bouquetResponse = _baxiService.GetBouquetAddons(bouquet).Result;
            Console.WriteLine("Bouquet Addons: " + bouquetResponse.Status);
        }

        private void ChangeCableTvSubscription()
        {
            var cableSubscription = new CableSubscriptionBody
            {
                ServiceType = "dstv",
                ProductCode = "PRWFRNSE36",
                ProductMonthsPaidFor = "1",
                AgentId = RandomNumber(),
                AgentReference = RandomNumber(),
                SmartcardNumber = "4131953321",
                TotalAmount = "29300",
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
            var serviceType = new ServiceBody()
            {
                ServiceType = "glo"
            };
            var epinBouquets = _baxiService.GetEpinBundles(serviceType).Result;
            Console.WriteLine("Epin Bouquets: " + epinBouquets.Data[0].Amount);
        }

        private void PurchaseEpin()
        {
            var epin = new EpinBody
            {
                ServiceType = "glo",
                PinValue = 50,
                NumberOfPins = 1,
                AgentId = RandomNumber(),
                AgentReference = RandomNumber(),
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
            var serviceType = new ServiceBody()
            {
                ServiceType = "jamb"
            };
            var jambProviders = _baxiService.GetJambProducts(serviceType).Result;
            Console.WriteLine("Jamb Providers: " + jambProviders.Data[0].Id);
        }

        private void PurchaseJambProduct()
        {
            var jambProduct = new JambProductBody
            {
                ServiceType = "jamb",
                AccountNumber = "9678528352",
                ProductCode = "DE",
                Phonenumber = "08000000000",
                AgentReference = RandomNumber(),
                Amount = 4000
            };
            var jambProductResponse = _baxiService.PurchaseJambProduct(jambProduct).Result;
            Console.WriteLine("Purchase Jamb Product Response: " + jambProductResponse.Data.ProviderStatusCode);
        }

        private void GetElectricityBillers()
        {
            var electricityBillers = _baxiService.GetElectricityBillers().Result;
            Console.WriteLine("Electricity Billers: " + electricityBillers.Data.Providers[0].Name);
        }

        private void ElectricityAccountValidation()
        {
            var providerBundle = new ProviderBundleBody
            {
                ServiceType = "ikeja_electric_prepaid",
                AccountNumber = "04042404048",
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
                Phonenumber = "08000000000",
                AgentReference = RandomNumber(),
                Amount = 1000,
                AgentId = RandomNumber()
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
                Phonenumber = "08000000000",
                AgentReference = RandomNumber(),
                Amount = 1000,
                AgentId = RandomNumber()
            };
            var electricityResponse = _baxiService.PurchasePrePaidElectricity(electricity).Result;
            Console.WriteLine("Purchase Pre Paid Electricity Response: " + electricityResponse.Data.StatusCode);
        }

        private string RandomNumber()
        {
            var random = new Random();
            var randomNumber = random.Next(1, 1000);
            return randomNumber.ToString();
        }
    }
}