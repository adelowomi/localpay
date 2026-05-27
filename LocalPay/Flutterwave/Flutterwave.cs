using System.Threading;
using System.Threading.Tasks;
using LocalPay.Flutterwave.Models;
using LocalPay.Interfaces;

namespace LocalPay.Flutterwave
{
    /// <summary>
    /// Default <see cref="IFlutterwavePayments"/> implementation. The underlying
    /// <see cref="IFlutterwaveService"/> Refit client is provided by
    /// <c>IServiceCollection.AddFlutterwave(...)</c> and uses <c>IHttpClientFactory</c>.
    /// </summary>
    public class FlutterwavePayments : IFlutterwavePayments
    {
        private readonly IFlutterwaveService _service;

        public FlutterwavePayments(IFlutterwaveService service)
        {
            _service = service;
        }

        public Task<TransferResponse> InitiateNgnTransfer(TransferPayloadNGN payload, CancellationToken cancellationToken = default)
            => _service.InitiateNgnTransfer(payload, cancellationToken);

        public Task<PaymentInitializationResponse> InitiatePayment(PaymentPayload payload, CancellationToken cancellationToken = default)
            => _service.InitiatePayment(payload, cancellationToken);

        public Task<PaymentResponse> InitiateTokenizedPayment(TokenizeChargeModel payload, CancellationToken cancellationToken = default)
            => _service.InitiateTokenizedPayment(payload, cancellationToken);

        public Task<PaymentResponse> ValidatePayment(long transactionId, CancellationToken cancellationToken = default)
            => _service.ValidatePayment(transactionId, cancellationToken);

        public Task<TransferResponse> GetTransfer(long id, CancellationToken cancellationToken = default)
            => _service.GetTransfer(id, cancellationToken);

        public Task<GetBanksResponse> GetBanks(string country, CancellationToken cancellationToken = default)
            => _service.GetBanks(country, cancellationToken);

        public Task<RefundResponse> RefundTransaction(long transactionId, RefundPayload payload, CancellationToken cancellationToken = default)
            => _service.RefundTransaction(transactionId, payload, cancellationToken);
    }
}
