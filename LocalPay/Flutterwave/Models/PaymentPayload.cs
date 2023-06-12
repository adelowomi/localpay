namespace LocalPay.Flutterwave.Models
{
    public class PaymentPayload
    {
        public string tx_ref { get; set; }
        public string amount { get; set; }
        public string payment_options { get; set; }
        public Customer customer { get; set; }
        public string redirect_url { get; set; }
        public Customization customization { get; set; }
        public string currency { get; set; }
    }
}