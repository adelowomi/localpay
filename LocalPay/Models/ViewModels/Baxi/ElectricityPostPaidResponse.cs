using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class ElectricityPostPaidResponse :AirtimeResponse
    {
        [JsonProperty("tokenCode")]
        public string TokenCode { get; set; }

        [JsonProperty("tokenAmount")]
        public int TokenAmount { get; set; }

        [JsonProperty("amountOfPower")]
        public string AmountOfPower { get; set; }
    }
}
