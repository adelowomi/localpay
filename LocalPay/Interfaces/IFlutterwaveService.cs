using System.Threading.Tasks;
using LocalPay.Flutterwave.Models;
using Refit;

namespace LocalPay.Interfaces
{
    public interface IFlutterwaveService
    {
        [Post("/transfers")]
        Task<TransferResponse> InitiateNgnTransfer([Body] TransferPayloadNGN payload);

        [Post("/payments")]
        Task<PaymentInitializationResponse> InitiatePayment([Body] PaymentPayload payload);

        [Post("/tokenized-charges")]
        Task<PaymentResponse> InitiateTokenizedPayment([Body] TokenizeChargeModel payload);

        [Get("/transactions/{transactionId}/verify")]
        Task<PaymentResponse> ValidatePayment([AliasAs("transactionId")] int transactionId);

        [Get("/transfers/{id}")]
        Task<TransferResponse> GetTransfer([AliasAs("id")] int id);

        [Get("/banks/{country}")]
        Task<GetBanksResponse> GetBanks([AliasAs("country")] string country);

    }
}