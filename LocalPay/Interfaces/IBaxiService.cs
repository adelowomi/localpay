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

         [Get("billers/category/all")]
            Task<BaxiResponse<List<BIllerCategoryResponse>>> GetBillerCategory();
    }
}