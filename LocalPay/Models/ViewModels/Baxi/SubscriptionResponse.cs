using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class SubscriptionResponse : AirtimeResponse
    {
        [JsonProperty("baxiReference")]
        public int BaxiReference { get; set; }

        [JsonProperty("provider_message")]
        public string ProviderMessage { get; set; }
    }
}
