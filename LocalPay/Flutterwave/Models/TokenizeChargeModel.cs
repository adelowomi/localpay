namespace LocalPay.Flutterwave.Models
{
    public class TokenizeChargeModel
    {
        public string token { get; set; }
        public string currency { get; set; }
        public string country { get; set; }
        public int amount { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string ip { get; set; }
        public string narration { get; set; }
        public string tx_ref { get; set; }
    }
}