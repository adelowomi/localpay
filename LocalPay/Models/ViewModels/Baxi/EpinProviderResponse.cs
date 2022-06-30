using Newtonsoft.Json;
using System.Collections.Generic;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class EpinProviderResponse
    {
        [JsonProperty("providers")]
        public List<BillerCategoryResponse> Providers {get;set;}
    }
}
