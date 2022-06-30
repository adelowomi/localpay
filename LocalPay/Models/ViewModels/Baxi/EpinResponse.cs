using Newtonsoft.Json;
using System.Collections.Generic;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class EpinResponse :AirtimeResponse
    {
        [JsonProperty("pins")]
        public List<PinResponse> Pins { get; set; }
    }
}
