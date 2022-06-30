using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class PinResponse
    {
        [JsonProperty("instructions")]
        public string Instructions { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }

        [JsonProperty("expiresOn")]
        public string ExpiresOn { get; set; }
    }
}