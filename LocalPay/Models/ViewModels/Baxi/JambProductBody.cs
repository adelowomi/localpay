using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class JambProductBody :JambCustomerBody
    {
        [JsonPropertyName("phone")]
        public string Phonenumber { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("agentReference")]
        public string AgentReference { get; set; }
    }
}
