using System.Collections.Generic;
using System.Threading.Tasks;
using LocalPay.Baxi;
using LocalPay.Interfaces;
using LocalPay.Models.UtilityModels;
using LocalPay.Models.ViewModels.Baxi;
using Models.InitializationModels;
using Refit;

namespace LocalPay
{
    public class BaxiPayments : IBaxiPayments
    {
        private readonly BaxiInitializationPayload _options;
        private readonly IBaxiService _baxiService;
        private string baseUrl = "https://payments.baxipay.com.ng/api/baxipay";
        public BaxiPayments(BaxiInitializationPayload options)
        {
            _options = options;
            _baxiService =  RestService.For<IBaxiService>(baseUrl,
                new RefitSettings
                {
                    AuthorizationHeaderValueGetter = () => AuthorizationHeaderValueProvider()
                });
        }

        private Task<string> AuthorizationHeaderValueProvider()
        {
            return Task.Run(() => _options.APIKey);
        }

        public async Task<BaxiResponse<BalanceResponse>> GetBalance()
        {
            return await _baxiService.GetBalance();
        }

        public async Task<BaxiResponse<List<BillerCategoryResponse>>> GetBillerCategory()
        {
            return await _baxiService.GetBillerCategory();
        }

        public async Task<BaxiResponse<List<BillerResponse>>> GetBillerByCategory(string serviceType)
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

        public async Task GetDataBundleServiceProviders()
        {
            await _baxiService.GetDataBundleServiceProviders();
        }

        public async Task<BaxiResponse<List<ProviderBundleResponse>>> GetProviderBundles(ProviderBundleBody providerBundle)
        {
            return await _baxiService.GetProviderBundles(providerBundle);
        }

        public async Task<BaxiResponse<AirtimeResponse>> PurchaseDataBundle(DataBundleBody dataBundle)
        {
            return await _baxiService.PurchaseDataBundle(dataBundle);
        }

        public async Task<BaxiResponse<MultichoiceAccountResponse>> MultichoiceAccountValidation(ProviderBundleBody providerBundle)
        {
            return await _baxiService.MultichoiceAccountValidation(providerBundle);
        }

        public async Task<BaxiResponse<SubscriptionResponse>> SubscriptionRenewal(SubscriptionBody subscription)
        {
            return await _baxiService.SubscriptionRenewal(subscription);
        }

        public async Task<BaxiResponse<List<ProviderBouquetResponse>>> GetProviderBouquets(string serviceType)
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

        public async Task<BaxiResponse<EpinProviderResponse>> GetEpinProviders()
        {
            return await _baxiService.GetEpinProviders();
        }

        public async Task<BaxiResponse<EpinBundleResponse>> GetEpinBundles(string serviceType)
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

        public async Task<BaxiResponse<List<JambProductResponse>>> GetJambProducts(string serviceType)
        {
            return await _baxiService.GetJambProducts(serviceType);
        }

        public async Task<BaxiResponse<JambProviderResponse>> PurchaseJambProduct(JambProductBody jambProduct)
        {
            return await _baxiService.PurchaseJambProduct(jambProduct);
        }

        public async Task<BaxiResponse<List<BillersElectricityResponse>>> GetElectricityBillers()
        {
            return await _baxiService.GetElectricityBillers();
        }

        public async Task<BaxiResponse<AccountValidationResponse>> AccountValidation(ProviderBundleBody providerBundle)
        {
            return await _baxiService.AccountValidation(providerBundle);
        }
    }
}