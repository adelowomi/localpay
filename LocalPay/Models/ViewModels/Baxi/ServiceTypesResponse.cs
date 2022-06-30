using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class ServiceTypesResponse
    {
        [JsonProperty("ikeja_electric_prepaid")]
        public string IkejaElectricPrepaid { get; set; }

        [JsonProperty("ikeja_electric_postpaid")]
        public string IkejaElectricPostpaid { get; set; }

        [JsonProperty("ibadan_electric_prepaid")]
        public string IbadanElectricPrepaid { get; set; }

        [JsonProperty("ibadan_electric_postpaid")]
        public string IbadanElectricPostpaid { get; set; }

        [JsonProperty("eko_electric_prepaid")]
        public string EkoElectricPrepaid { get; set; }

        [JsonProperty("eko_electric_postpaid")]
        public string EkoElectricPostpaid { get; set; }

        [JsonProperty("kedco_electric_prepaid")]
        public string KedcoElectricPrepaid { get; set; }

        [JsonProperty("kedco_electric_postpaid")]
        public string KedcoElectricPostpaid { get; set; }

        [JsonProperty("abuja_electric_prepaid")]
        public string AbujaElectricPrepaid { get; set; }

        [JsonProperty("abuja_electric_postpaid")]
        public string AbujaElectricPostpaid { get; set; }

        [JsonProperty("jos_electric_prepaid")]
        public string JosElectricPrepaid { get; set; }

        [JsonProperty("jos_electric_postpaid")]
        public string JosElectricPostpaid { get; set; }

        [JsonProperty("Kaduna_electric_prepaid")]
        public string KadunaElectricPrepaid { get; set; }

        [JsonProperty("enugu_electric_prepaid")]
        public string EnuguElectricPrepaid { get; set; }

        [JsonProperty("enugu_electric_postpaid")]
        public string EnuguElectricPostpaid { get; set; }

        [JsonProperty("portharcourt_electric_prepaid")]
        public string PortHarcourtElectricPrepaid { get; set; }

        [JsonProperty("portharcourt_electric_postpaid")]
        public string PortHarcourtElectricPostpaid { get; set; }

    }
}