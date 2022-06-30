using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class AirtimeBody:BaxiBody
    {

        [JsonPropertyName("plan")]
        public string Plan { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

    }
}
