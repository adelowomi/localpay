using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LocalPay.Flutterwave.Models;
using LocalPay.Interfaces;
using Refit;

namespace LocalPay.Flutterwave
{
    public class FlutterwavePayments : IFlutterwavePayments
    {
        private readonly FlutterwaveInitializationPayload _options;
        private readonly IFlutterwaveService _flutterwaveService;
        private string baseUrl = "https://api.flutterwave.com/v3";
        public FlutterwavePayments(FlutterwaveInitializationPayload options)
        {
            _options = options;
            var client = new HttpClient(new HttpClientHandler())
            {
                BaseAddress = new Uri(baseUrl)
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{_options.SecretKey}");
            var buider = RequestBuilder.ForType<IFlutterwaveService>();
            _flutterwaveService = RestService.For(client, buider);
        }

        public async Task<TransferResponse> InitiateNgnTransfer(TransferPayloadNGN payload)
        {
            return await _flutterwaveService.InitiateNgnTransfer(payload);
        }

        public async Task<PaymentInitializationResponse> InitiatePayment(PaymentPayload payload)
        {
            return await _flutterwaveService.InitiatePayment(payload);
        }

        public async Task<PaymentResponse> InitiateTokenizedPayment(TokenizeChargeModel payload)
        {
            return await _flutterwaveService.InitiateTokenizedPayment(payload);
        }

        public async Task<PaymentResponse> ValidatePayment(int transactionId)
        {
            return await _flutterwaveService.ValidatePayment(transactionId);
        }

        public async Task<TransferResponse> GetTransfer(int id)
        {
            return await _flutterwaveService.GetTransfer(id);
        }

        public async Task<GetBanksResponse> GetBanks(string country)
        {
            return await _flutterwaveService.GetBanks(country);
        }
    }
}