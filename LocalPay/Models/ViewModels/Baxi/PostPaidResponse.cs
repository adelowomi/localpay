using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class PostPaidResponse :AirtimeResponse
    {
        [JsonProperty("provider_message")]
        public string ProviderMessage { get; set; }

        [JsonProperty("baxiReference")]
        public int BaxiReference { get; set; }
    }
}