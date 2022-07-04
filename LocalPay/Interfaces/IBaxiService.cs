using System.Collections.Generic;
using System.Threading.Tasks;
using LocalPay.Models.UtilityModels;
using LocalPay.Models.ViewModels.Baxi;
using Refit;

namespace LocalPay.Interfaces
{
    public interface IBaxiService
    {
        [Get("/superagent/account/balance")]
        Task<BaxiResponse<BalanceResponse>> GetBalance();

        [Get("/billers/category/all")]
        Task<BaxiResponse<List<BillerCategoryResponse>>> GetBillerCategory();

        [Post("/billers/services/category")]
        Task<BaxiResponse<List<BillerResponse>>> GetBillerByCategory([Body] ServiceBody serviceType);

        [Get("/services/airtime/providers")]
        Task<BaxiResponse<BaxiProvidersResponse>> GetBaxiProviders();

        [Post("/services/airtime/request")]
        Task<BaxiResponse<AirtimeResponse>> PurchaseAirtime([Body] AirtimeBody airtime);

        [Get("/services/databundle/providers")]
        Task<BaxiResponse<DataProviderResponse>> GetDataBundleServiceProviders();

        [Post("/services/databundle/bundles")]
        Task<BaxiResponse<List<ProviderBundleResponse>>> GetProviderBundles([Body] ProviderBundleBody providerBundle);

        [Post("/services/databundle/request")]
        Task<BaxiResponse<AirtimeResponse>> PurchaseDataBundle([Body] DataBundleBody dataBundle);

        [Post("/services/databundle/request")]
        Task<BaxiResponse<AirtimeResponse>> PurchaseSpectranetDataBundle([Body] DataBundleBody dataBundle);

        [Post("/services/namefinder/query")]
        Task<BaxiResponse<MultichoiceAccountResponse>> MultichoiceAccountValidation([Body] ProviderBundleBody providerBundle);

        [Post("/services/multichoice/request")]
        Task<BaxiResponse<SubscriptionResponse>> SubscriptionRenewal([Body] SubscriptionBody subscription);

        [Post("/services/multichoice/list")]
        Task<BaxiResponse<List<ProviderBouquetResponse>>> GetProviderBouquets([Body] ServiceBody serviceType);

        [Post("/services/multichoice/addons")]
        Task<BaxiResponse<List<ProviderBouquetResponse>>> GetBouquetAddons([Body] BouquetBody bouquet);

        [Post("/services/multichoice/request")]
        Task<BaxiResponse<AirtimeResponse>> ChangeCableTvSubscription([Body] CableSubscriptionBody subscription);

        [Get("/services/epin/providers")]
        Task<BaxiResponse<DataProviderResponse>> GetEpinProviders();

        [Post("/services/epin/bundles")]
        Task<BaxiResponse<List<EpinBundleResponse>>> GetEpinBundles([Body] ServiceBody serviceType);

        [Post("/services/epin/request")]
        Task<BaxiResponse<EpinResponse>> PurchaseEpin([Body] EpinBody epin);

        [Post("/services/namefinder/query")]
        Task<BaxiResponse<JambCustomerResponse>> AccountValidation([Body] JambCustomerBody jambCustomer);

        [Post("/exampins/products")]
        Task<BaxiResponse<List<JambProductResponse>>> GetJambProducts([Body] ServiceBody serviceType);

        [Post("/services/exampin/request")]
        Task<BaxiResponse<JambProviderResponse>> PurchaseJambProduct([Body] JambProductBody jambProduct);

        [Get("/services/electricity/billers")]
        Task<BaxiResponse<DataProviderResponse>> GetElectricityBillers();

        [Post("/services/namefinder/query")]
        Task<BaxiResponse<AccountValidationResponse>> AccountValidation([Body] ProviderBundleBody providerBundle);

        [Post("/services/electricity/request")]
        Task<BaxiResponse<PostPaidResponse>> PurchasePostPaidElectricity([Body] ElectricityBody electricity);

        [Post("/services/electricity/request")]
        Task<BaxiResponse<ElectricityPrePaidResponse>> PurchasePrePaidElectricity([Body] ElectricityBody electricity);
        


    }
}