using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class ElectricityBody :BaxiBody
    {
        [JsonPropertyName("phone")]
        public string Phonenumber { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }
    }
}
