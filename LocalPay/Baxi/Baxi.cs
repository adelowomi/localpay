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

        public async Task<BaxiResponse<List<BIllerCategoryResponse>>> GetBillerCategory()
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
    }
}