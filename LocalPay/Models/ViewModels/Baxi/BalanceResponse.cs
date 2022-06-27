using System;
using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class BalanceResponse
    {
        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("lastDeposit")]
        public DateTime LastDeposit { get; set; }
    }
}