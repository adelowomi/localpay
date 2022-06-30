using Newtonsoft.Json;


namespace LocalPay.Models.ViewModels.Baxi
{
    public class AccountValidationResponse
    {
        [JsonProperty("user")]
        public BaxiCustomerResponse<AccountRawOutputResponse> User { get; set; }
    }
}
