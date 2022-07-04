using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class ElectricityPrePaidResponse :AirtimeResponse
    {

        [JsonProperty("tokenCode")]
        public string TokenCode { get; set; }

        [JsonProperty("tokenAmount")]
        public double TokenAmount { get; set; }

        [JsonProperty("amountOfPower")]
        public string AmountOfPower { get; set; }

        [JsonProperty("creditToken")]
        public string CreditToken { get; set; }

        [JsonProperty("resetToken")]
        public object ResetToken { get; set; }

        [JsonProperty("configureToken")]
        public object ConfigureToken { get; set; }

        [JsonProperty("rawOutput")]
        public ElectricityRawOutputResponse RawOutput { get; set; }

        [JsonProperty("provider_message")]
        public string ProviderMessage { get; set; }

        [JsonProperty("baxiReference")]
        public int BaxiReference { get; set; }
    }
}
