using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class JambRawOutputResponse
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("gsmNo")]
        public string GsmNo { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
