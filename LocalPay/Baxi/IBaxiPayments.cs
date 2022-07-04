using System.Collections.Generic;
using System.Threading.Tasks;
using LocalPay.Models.UtilityModels;
using LocalPay.Models.ViewModels.Baxi;

namespace LocalPay.Baxi
{
    public interface IBaxiPayments
    {
        Task<BaxiResponse<BalanceResponse>> GetBalance();
        Task<BaxiResponse<List<BillerCategoryResponse>>> GetBillerCategory();
        Task<BaxiResponse<List<BillerResponse>>> GetBillerByCategory(ServiceBody serviceType);
        Task<BaxiResponse<BaxiProvidersResponse>> GetBaxiProviders();
        Task<BaxiResponse<AirtimeResponse>> PurchaseAirtime(AirtimeBody airtimeBody);
        Task<BaxiResponse<DataProviderResponse>> GetDataBundleServiceProviders();
        Task<BaxiResponse<List<ProviderBundleResponse>>> GetProviderBundles(ProviderBundleBody providerBundle);
        Task<BaxiResponse<AirtimeResponse>> PurchaseDataBundle(DataBundleBody dataBundle);
        Task<BaxiResponse<AirtimeResponse>> PurchaseSpectranetDataBundle(DataBundleBody dataBundle);
        Task<BaxiResponse<MultichoiceAccountResponse>> MultichoiceAccountValidation(ProviderBundleBody providerBundle);
        Task<BaxiResponse<SubscriptionResponse>> SubscriptionRenewal(SubscriptionBody subscription);
        Task<BaxiResponse<List<ProviderBouquetResponse>>> GetProviderBouquets(ServiceBody serviceType);
        Task<BaxiResponse<List<ProviderBouquetResponse>>> GetBouquetAddons(BouquetBody bouquet);
        Task<BaxiResponse<AirtimeResponse>> ChangeCableTvSubscription(CableSubscriptionBody cableSubscription);
        Task<BaxiResponse<DataProviderResponse>> GetEpinProviders();
        Task<BaxiResponse<List<EpinBundleResponse>>> GetEpinBundles(ServiceBody serviceType);
        Task<BaxiResponse<EpinResponse>> PurchaseEpin(EpinBody epin);
        Task<BaxiResponse<JambCustomerResponse>> AccountValidation(JambCustomerBody jambCustomer);
        Task<BaxiResponse<List<JambProductResponse>>> GetJambProducts(ServiceBody serviceType);
        Task<BaxiResponse<JambProviderResponse>> PurchaseJambProduct(JambProductBody jambProduct);
        Task<BaxiResponse<DataProviderResponse>> GetElectricityBillers();
        Task<BaxiResponse<AccountValidationResponse>> AccountValidation(ProviderBundleBody providerBundle);
        Task<BaxiResponse<PostPaidResponse>> PurchasePostPaidElectricity(ElectricityBody electricity);
        Task<BaxiResponse<ElectricityPrePaidResponse>> PurchasePrePaidElectricity(ElectricityBody electricity);
    }
}