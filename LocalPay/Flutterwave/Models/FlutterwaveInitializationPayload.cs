namespace LocalPay.Flutterwave.Models
{
    /// <summary>
    /// Options used to configure the Flutterwave client.
    /// </summary>
    public class FlutterwaveInitializationPayload
    {
        /// <summary>
        /// Flutterwave secret key (e.g. <c>FLWSECK-...</c> for production or <c>FLWSECK_TEST-...</c> for sandbox).
        /// </summary>
        public string SecretKey { get; set; } = string.Empty;

        /// <summary>
        /// Base URL for the Flutterwave API. Defaults to v3 production.
        /// </summary>
        public string BaseUrl { get; set; } = "https://api.flutterwave.com/v3";

        /// <summary>
        /// Webhook secret hash configured in the Flutterwave dashboard, used to verify
        /// incoming webhook signatures. Required only if your app consumes webhooks.
        /// </summary>
        public string? WebhookSecretHash { get; set; }
    }
}
