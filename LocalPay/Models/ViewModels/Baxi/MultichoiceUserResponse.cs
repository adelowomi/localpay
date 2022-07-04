using Newtonsoft.Json;
using System;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class MultichoiceUserResponse : BaxiCustomerResponse<RawOutputResponse>
    {
        [JsonProperty("currentBouquetRaw")]
        public CurrentBouquetRawResponse CurrentBouquetRaw { get; set; }

        [JsonProperty("currentBouquet")]
        public string CurrentBouquet { get; set; }

       
    }
}
