using System;
using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class SubscriptionBody
    {
        [JsonPropertyName("isBoxOffice")]
        public bool IsBoxOffice { get; set; }

        [JsonPropertyName("total_amount")]
        public string TotalAmount { get; set; }

        [JsonPropertyName("service_type")]
        public string ServiceType { get; set; }

        [JsonPropertyName("agentId")]
        public string AgentId { get; set; }

        [JsonPropertyName("agentReference")]
        public string AgentReference { get; set; }

        [JsonPropertyName("smartcard_number")]
        public string SmartcardNumber { get; set; }


    }
}
