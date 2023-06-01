using System.Threading.Tasks;
using LocalPay.Flutterwave.Models;

namespace LocalPay.Flutterwave
{
    public interface IFlutterwavePayments
    {
        Task<TransferResponse> InitiateNgnTransfer(TransferPayloadNGN payload);
        Task<PaymentInitializationResponse> InitiatePayment(PaymentPayload payload);

        Task<PaymentResponse> InitiateTokenizedPayment(TokenizeChargeModel payload);
        Task<PaymentResponse> ValidatePayment(int transactionId);

        Task<TransferResponse> GetTransfer(int id);
        Task<GetBanksResponse> GetBanks(string country);
    }
}