using System.Collections.Generic;
using Newtonsoft.Json;

namespace LocalPay.Flutterwave.Models
{
    public class GetBanksResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("data")]
        public List<Bank> Data { get; set; } = new List<Bank>();
    }

    public class Bank
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
    }
}
