using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using LocalPay.Baxi;
using LocalPay.Interfaces;
using LocalPay.Models.UtilityModels;
using LocalPay.Models.ViewModels.Baxi;
using Models.InitializationModels;
using Refit;
using System.Net.Http;
using System;

namespace LocalPay.Baxi
{
    public class BaxiPayments : IBaxiPayments
    {
        private readonly BaxiInitializationPayload _options;
        private readonly IBaxiService _baxiService;
        private string baseUrl = "https://payments.baxipay.com.ng/api/baxipay";
        public BaxiPayments(BaxiInitializationPayload options)
        {
            _options = options;
            var client = new HttpClient(new HttpClientHandler())
            {
                BaseAddress = new Uri(baseUrl)
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Api-key", _options.APIKey);
            var buider = RequestBuilder.ForType<IBaxiService>();
            _baxiService = RestService.For(client, buider);
            // RefitSettings settings = new RefitSettings{ AuthorizationHeaderValueGetter = () => AuthorizationHeaderValueProvider() };
            // _baxiService =  RestService.For<IBaxiService>(baseUrl, settings);
        }

        private Task<string> AuthorizationHeaderValueProvider()
        {
            var header = new AuthenticationHeaderValue("Bearer", _options.APIKey);
            return Task.Run(() => header.ToString());
        }

        public async Task<BaxiResponse<BalanceResponse>> GetBalance()
        {
            return await _baxiService.GetBalance();
        }

        public async Task<BaxiResponse<List<BillerCategoryResponse>>> GetBillerCategory()
        {
            return await _baxiService.GetBillerCategory();
        }

        public async Task<BaxiResponse<List<BillerResponse>>> GetBillerByCategory(ServiceBody serviceType)
        {
            return await _baxiService.GetBillerByCategory(serviceType);
        }

        public async Task<BaxiResponse<BaxiProvidersResponse>> GetBaxiProviders()
        {
            return await _baxiService.GetBaxiProviders();
        }

        public async Task<BaxiResponse<AirtimeResponse>> PurchaseAirtime(AirtimeBody airtime)
        {
            return await _baxiService.PurchaseAirtime(airtime);
        }

        public async Task<BaxiResponse<DataProviderResponse>> GetDataBundleServiceProviders()
        {
            return await _baxiService.GetDataBundleServiceProviders();
        }

        public async Task<BaxiResponse<List<ProviderBundleResponse>>> GetProviderBundles(ProviderBundleBody providerBundle)
        {
            return await _baxiService.GetProviderBundles(providerBundle);
        }

        public async Task<BaxiResponse<AirtimeResponse>> PurchaseDataBundle(DataBundleBody dataBundle)
        {
            return await _baxiService.PurchaseDataBundle(dataBundle);
        }


        public async Task<BaxiResponse<AirtimeResponse>> PurchaseSpectranetDataBundle(DataBundleBody dataBundle)
        {
            return await _baxiService.PurchaseSpectranetDataBundle(dataBundle);
        }

        public async Task<BaxiResponse<MultichoiceAccountResponse>> MultichoiceAccountValidation(ProviderBundleBody providerBundle)
        {
            return await _baxiService.MultichoiceAccountValidation(providerBundle);
        }

        public async Task<BaxiResponse<SubscriptionResponse>> SubscriptionRenewal(SubscriptionBody subscription)
        {
            return await _baxiService.SubscriptionRenewal(subscription);
        }

        public async Task<BaxiResponse<List<ProviderBouquetResponse>>> GetProviderBouquets(ServiceBody serviceType)
        {
            return await _baxiService.GetProviderBouquets(serviceType);
        }

        public async Task<BaxiResponse<List<ProviderBouquetResponse>>> GetBouquetAddons(BouquetBody bouquet)
        {
            return await _baxiService.GetBouquetAddons(bouquet);
        }

        public async Task<BaxiResponse<AirtimeResponse>> ChangeCableTvSubscription(CableSubscriptionBody cableSubscription)
        {
            return await _baxiService.ChangeCableTvSubscription(cableSubscription);
        }

        public async Task<BaxiResponse<DataProviderResponse>> GetEpinProviders()
        {
            return await _baxiService.GetEpinProviders();
        }

        public async Task<BaxiResponse<List<EpinBundleResponse>>> GetEpinBundles(ServiceBody serviceType)
        {
            return await _baxiService.GetEpinBundles(serviceType);
        }

        public async Task<BaxiResponse<EpinResponse>> PurchaseEpin(EpinBody epin)
        {
            return await _baxiService.PurchaseEpin(epin);
        }

        public async Task<BaxiResponse<JambCustomerResponse>> AccountValidation(JambCustomerBody jambCustomer)
        {
            return await _baxiService.AccountValidation(jambCustomer);
        }

        public async Task<BaxiResponse<List<JambProductResponse>>> GetJambProducts(ServiceBody serviceType)
        {
            return await _baxiService.GetJambProducts(serviceType);
        }

        public async Task<BaxiResponse<JambProviderResponse>> PurchaseJambProduct(JambProductBody jambProduct)
        {
            return await _baxiService.PurchaseJambProduct(jambProduct);
        }

        public async Task<BaxiResponse<DataProviderResponse>> GetElectricityBillers()
        {
            return await _baxiService.GetElectricityBillers();
        }

        public async Task<BaxiResponse<AccountValidationResponse>> AccountValidation(ProviderBundleBody providerBundle)
        {
            return await _baxiService.AccountValidation(providerBundle);
        }

        public async Task<BaxiResponse<ElectricityPrePaidResponse>> PurchasePrePaidElectricity(ElectricityBody electricity)
        {
            return await _baxiService.PurchasePrePaidElectricity(electricity);
        }

        public async Task<BaxiResponse<PostPaidResponse>> PurchasePostPaidElectricity(ElectricityBody electricity)
        {
            return await _baxiService.PurchasePostPaidElectricity(electricity);
        }
    }
}