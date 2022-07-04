using System.Text.Json.Serialization;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class SpectranetBody :DataBundleBody
    {
        [JsonPropertyName("package")]
        public string Package { get; set; }

    }
}