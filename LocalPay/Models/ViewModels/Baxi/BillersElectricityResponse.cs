using Newtonsoft.Json;
using System.Collections.Generic;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class BillersElectricityResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("service_types")]
        public ServiceTypesResponse ServiceTypes { get; set; }
    }

}
