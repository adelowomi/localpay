using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class ServiceBody
    {
        [JsonPropertyName("service_type")]
        public string ServiceType { get; set; }
    }
}