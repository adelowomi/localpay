using Newtonsoft.Json;

namespace LocalPay.Models.ViewModels.Baxi
{
    public class ElectricityRawOutputResponse
    {
       [JsonProperty("installationFee")]
        public object InstallationFee { get; set; }

        [JsonProperty("lossOfRevenue")]
        public object LossOfRevenue { get; set; }

        [JsonProperty("penalty")]
        public object Penalty { get; set; }

        [JsonProperty("tariffBaseRate")]
        public double TariffBaseRate { get; set; }

        [JsonProperty("tokenAmount")]
        public double TokenAmount { get; set; }

        [JsonProperty("costOfUnit")]
        public double CostOfUnit { get; set; }

        [JsonProperty("meterServiceCharge")]
        public object MeterServiceCharge { get; set; }

        [JsonProperty("reconnectionFee")]
        public object ReconnectionFee { get; set; }

        [JsonProperty("administrativeCharge")]
        public object AdministrativeCharge { get; set; }

        [JsonProperty("creditToken")]
        public string CreditToken { get; set; }

        [JsonProperty("fixChargeAmount")]
        public int FixChargeAmount { get; set; }

        [JsonProperty("exchangeReference")]
        public string ExchangeReference { get; set; }

        [JsonProperty("tariff")]
        public string Tariff { get; set; }

        [JsonProperty("meterCost")]
        public object MeterCost { get; set; }

        [JsonProperty("resetToken")]
        public object ResetToken { get; set; }

        [JsonProperty("taxAmount")]
        public double TaxAmount { get; set; }

        [JsonProperty("configureToken")]
        public object ConfigureToken { get; set; }

        [JsonProperty("debtAmount")]
        public object DebtAmount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("amountOfPower")]
        public string AmountOfPower { get; set; }
    }
}