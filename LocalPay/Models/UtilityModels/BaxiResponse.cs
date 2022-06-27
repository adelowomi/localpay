using System.Collections.Generic;
using Newtonsoft.Json;

namespace LocalPay.Models.UtilityModels
{
    public class BaxiResponse<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }
    }
}