using System;
using Newtonsoft.Json;

namespace LocalPay.Flutterwave.Models
{
    public class PaymentResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("data")]
        public PaymentResponseData? Data { get; set; }
    }

    public class PaymentResponseData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("tx_ref")]
        public string TxRef { get; set; } = string.Empty;

        [JsonProperty("flw_ref")]
        public string? FlwRef { get; set; }

        [JsonProperty("device_fingerprint")]
        public string? DeviceFingerprint { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonProperty("charged_amount")]
        public decimal ChargedAmount { get; set; }

        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }

        [JsonProperty("merchant_fee")]
        public decimal MerchantFee { get; set; }

        [JsonProperty("processor_response")]
        public string? ProcessorResponse { get; set; }

        [JsonProperty("auth_model")]
        public string? AuthModel { get; set; }

        [JsonProperty("ip")]
        public string? Ip { get; set; }

        [JsonProperty("narration")]
        public string? Narration { get; set; }

        [JsonProperty("status")]
        public string TransactionStatus { get; set; } = string.Empty;

        [JsonProperty("payment_type")]
        public string? PaymentType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("amount_settled")]
        public decimal AmountSettled { get; set; }

        [JsonProperty("card")]
        public PaymentResponseCard? Card { get; set; }
    }
}
