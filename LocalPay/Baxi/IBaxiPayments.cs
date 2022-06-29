using System.Collections.Generic;
using System.Threading.Tasks;
using LocalPay.Models.UtilityModels;
using LocalPay.Models.ViewModels.Baxi;

namespace LocalPay.Baxi
{
    public interface IBaxiPayments
    {
        Task<BaxiResponse<BalanceResponse>> GetBalance();
        Task<BaxiResponse<List<BIllerCategoryResponse>>> GetBillerCategory();
        Task<BaxiResponse<List<BillerResponse>>> GetBillerByCategory(string serviceType);
        Task<BaxiResponse<BaxiProvidersResponse>> GetBaxiProviders();
    }
}