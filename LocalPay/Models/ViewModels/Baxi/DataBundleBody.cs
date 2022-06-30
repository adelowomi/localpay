using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class DataBundleBody : AirtimeBody
    {
        [JsonPropertyName("datacode")]
        public string DataCode { get; set; }

        [JsonPropertyName("package")]
        public string Package { get; set; }

    }
}
