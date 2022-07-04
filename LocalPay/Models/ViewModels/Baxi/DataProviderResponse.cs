using Newtonsoft.Json;
using System.Collections.Generic;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class DataProviderResponse
    {
        [JsonProperty("providers")]
        public List<ProviderResponse> Providers { get; set; }
    }
}