namespace LocalPay.Flutterwave.Models
{
    public class PaymentInitializationResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public PaymentInitializationResponseData data { get; set; }
    }

    public class PaymentInitializationResponseData
    {
        public string link { get; set; }
    }
}