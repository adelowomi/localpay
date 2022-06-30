using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class ItemResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}