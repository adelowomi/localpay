using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class EpinBody : BaxiBody
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("pinValue")]
        public int PinValue { get; set; }

        [JsonPropertyName("numberOfPins")]
        public int NumberOfPins { get; set; }
    }
}
