using System.Threading;
using System.Threading.Tasks;
using LocalPay.Flutterwave.Models;
using Refit;

namespace LocalPay.Interfaces
{
    /// <summary>
    /// Refit-defined HTTP contract for the Flutterwave v3 REST API.
    /// Consumers should depend on <see cref="LocalPay.Flutterwave.IFlutterwavePayments"/>
    /// rather than this interface directly.
    /// </summary>
    public interface IFlutterwaveService
    {
        [Post("/transfers")]
        Task<TransferResponse> InitiateNgnTransfer([Body] TransferPayloadNGN payload, CancellationToken cancellationToken = default);

        [Post("/payments")]
        Task<PaymentInitializationResponse> InitiatePayment([Body] PaymentPayload payload, CancellationToken cancellationToken = default);

        [Post("/tokenized-charges")]
        Task<PaymentResponse> InitiateTokenizedPayment([Body] TokenizeChargeModel payload, CancellationToken cancellationToken = default);

        [Get("/transactions/{transactionId}/verify")]
        Task<PaymentResponse> ValidatePayment(long transactionId, CancellationToken cancellationToken = default);

        [Get("/transfers/{id}")]
        Task<TransferResponse> GetTransfer(long id, CancellationToken cancellationToken = default);

        [Get("/banks/{country}")]
        Task<GetBanksResponse> GetBanks(string country, CancellationToken cancellationToken = default);

        [Post("/transactions/{transactionId}/refund")]
        Task<RefundResponse> RefundTransaction(long transactionId, [Body] RefundPayload payload, CancellationToken cancellationToken = default);
    }
}
