using System;
using Newtonsoft.Json;

namespace LocalPay.Flutterwave.Models
{
    public class RefundResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("data")]
        public RefundResponseData? Data { get; set; }
    }

    public class RefundResponseData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("tx_id")]
        public long TransactionId { get; set; }

        [JsonProperty("flw_ref")]
        public string? FlwRef { get; set; }

        [JsonProperty("wallet_id")]
        public long WalletId { get; set; }

        [JsonProperty("amount_refunded")]
        public decimal AmountRefunded { get; set; }

        [JsonProperty("status")]
        public string RefundStatus { get; set; } = string.Empty;

        [JsonProperty("destination")]
        public string? Destination { get; set; }

        [JsonProperty("meta")]
        public object? Meta { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
