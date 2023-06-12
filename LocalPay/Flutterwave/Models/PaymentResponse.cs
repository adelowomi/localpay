using System;

namespace LocalPay.Flutterwave.Models
{
    public class PaymentResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public PaymentResponseData data { get; set; }
    }
    public class PaymentResponseData
    {
        public int id { get; set; }
        public string tx_ref { get; set; }
        public string flw_ref { get; set; }
        public string device_fingerprint { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public int charged_amount { get; set; }
        public decimal app_fee { get; set; }
        public int merchant_fee { get; set; }
        public string processor_response { get; set; }
        public string auth_model { get; set; }
        public string ip { get; set; }
        public string narration { get; set; }
        public string status { get; set; }
        public string payment_type { get; set; }
        public DateTime created_at { get; set; }
        public int account_id { get; set; }
        public decimal amount_settled { get; set; }
        public PaymentResponseCard Card { get; set; }
    }
}