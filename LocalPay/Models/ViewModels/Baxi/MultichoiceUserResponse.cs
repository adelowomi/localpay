using Newtonsoft.Json;
using System;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class MultichoiceUserResponse : BaxiCustomerResponse<RawOutputResponse>
    {
        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("currentBouquetRaw")]
        public CurrentBouquetRawResponse CurrentBouquetRaw { get; set; }

        [JsonProperty("currentBouquet")]
        public string CurrentBouquet { get; set; }

       
    }
}
