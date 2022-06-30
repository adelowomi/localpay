using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class MultichoiceAccountResponse
    {
        [JsonProperty("user")]
        public MultichoiceUserResponse User { get; set; }
    }
}
