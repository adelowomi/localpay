using System.Collections.Generic;
using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class BaxiProvidersResponse
    {
        [JsonProperty("providers")]
        public List<BaxiProviderResponse> Providers { get; set; }
    }
}