using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public abstract class BaxiBody
    {
        [JsonPropertyName("agentId")]
        public string AgentId { get; set; }

        [JsonPropertyName("agentReference")]
        public string AgentReference { get; set; }

        [JsonPropertyName("service_type")]
        public string ServiceType { get; set; }
    }
}
