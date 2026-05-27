using System.Threading;
using System.Threading.Tasks;
using LocalPay.Flutterwave.Models;

namespace LocalPay.Flutterwave
{
    /// <summary>
    /// High-level Flutterwave client. Inject via DI after calling
    /// <c>services.AddFlutterwave(...)</c>.
    /// </summary>
    public interface IFlutterwavePayments
    {
        /// <summary>Initiate a domestic (NGN) bank transfer.</summary>
        Task<TransferResponse> InitiateNgnTransfer(TransferPayloadNGN payload, CancellationToken cancellationToken = default);

        /// <summary>Initiate a Standard (hosted) payment session and obtain a checkout link.</summary>
        Task<PaymentInitializationResponse> InitiatePayment(PaymentPayload payload, CancellationToken cancellationToken = default);

        /// <summary>Charge a previously-saved card token.</summary>
        Task<PaymentResponse> InitiateTokenizedPayment(TokenizeChargeModel payload, CancellationToken cancellationToken = default);

        /// <summary>Verify a transaction by Flutterwave transaction id.</summary>
        Task<PaymentResponse> ValidatePayment(long transactionId, CancellationToken cancellationToken = default);

        /// <summary>Fetch a transfer by id.</summary>
        Task<TransferResponse> GetTransfer(long id, CancellationToken cancellationToken = default);

        /// <summary>List banks supported in the given ISO country code (e.g. <c>NG</c>, <c>GH</c>, <c>KE</c>).</summary>
        Task<GetBanksResponse> GetBanks(string country, CancellationToken cancellationToken = default);

        /// <summary>Refund a transaction in full or in part.</summary>
        Task<RefundResponse> RefundTransaction(long transactionId, RefundPayload payload, CancellationToken cancellationToken = default);
    }
}
