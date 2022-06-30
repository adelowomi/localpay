using Newtonsoft.Json;
using System.Collections.Generic;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class CurrentBouquetRawResponse
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("items")]
        public List<ItemResponse> Items { get; set; }
    }
}