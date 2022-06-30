using Newtonsoft.Json;
using System;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class JambUserResponse : BaxiCustomerResponse<JambRawOutputResponse>
    {
        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
