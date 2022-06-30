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
        Task<BaxiResponse<List<BillerResponse>>> GetBillerByCategory(string serviceType);
        Task<BaxiResponse<BaxiProvidersResponse>> GetBaxiProviders();
        Task<BaxiResponse<AirtimeResponse>> PurchaseAirtime(AirtimeBody airtimeBody);
        Task GetDataBundleServiceProviders();
        Task<BaxiResponse<List<ProviderBundleResponse>>> GetProviderBundles(ProviderBundleBody providerBundle);
        Task<BaxiResponse<AirtimeResponse>> PurchaseDataBundle(DataBundleBody dataBundle);
        Task<BaxiResponse<MultichoiceAccountResponse>> MultichoiceAccountValidation(ProviderBundleBody providerBundle);
        Task<BaxiResponse<SubscriptionResponse>> SubscriptionRenewal(SubscriptionBody subscription);
        Task<BaxiResponse<List<ProviderBouquetResponse>>> GetProviderBouquets(string serviceType);
        Task<BaxiResponse<List<ProviderBouquetResponse>>> GetBouquetAddons(BouquetBody bouquet);
        Task<BaxiResponse<AirtimeResponse>> ChangeCableTvSubscription(CableSubscriptionBody cableSubscription);
        Task<BaxiResponse<EpinProviderResponse>> GetEpinProviders();
        Task<BaxiResponse<EpinBundleResponse>> GetEpinBundles(string serviceType);
        Task<BaxiResponse<EpinResponse>> PurchaseEpin(EpinBody epin);
        Task<BaxiResponse<JambCustomerResponse>> AccountValidation(JambCustomerBody jambCustomer);
        Task<BaxiResponse<List<JambProductResponse>>> GetJambProducts(string serviceType);
        Task<BaxiResponse<JambProviderResponse>> PurchaseJambProduct(JambProductBody jambProduct);
        Task<BaxiResponse<List<BillersElectricityResponse>>> GetElectricityBillers();
        Task<BaxiResponse<AccountValidationResponse>> AccountValidation(ProviderBundleBody providerBundle);
        Task<BaxiResponse<AirtimeResponse>> PurchasePostPaidElectricity(ElectricityBody electricity);
        Task<BaxiResponse<ElectricityPrePaidResponse>> PurchasePrePaidElectricity(ElectricityBody electricity);
        
        

    }
}