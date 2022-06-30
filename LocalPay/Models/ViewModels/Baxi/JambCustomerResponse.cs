using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class JambCustomerResponse
    {
        [JsonProperty("user")]
        public JambUserResponse User { get; set; }

    }
}
