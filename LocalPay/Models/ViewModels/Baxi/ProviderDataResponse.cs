using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class ProviderDataResponse
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }
    }
}