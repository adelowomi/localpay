using System.Collections.Generic;

namespace LocalPay.Flutterwave.Models
{
    public class GetBanksResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Banks> data { get; set; }
    }

    public class Banks
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }
}