using LocalPay.Flutterwave;
using LocalPay.Flutterwave.Models;
using LocalPayTestClient.Services.Abstraction;

namespace LocalPayTestClient.Services
{
    public class FlutterwaveTestService : IFlutterwaveTestService
    {
        private readonly IFlutterwavePayments _flutterwavePayments;

        public FlutterwaveTestService(IFlutterwavePayments flutterwavePayments)
        {
            _flutterwavePayments = flutterwavePayments;
        }

        public void RunTests()
        {
            InitiateNgnTransfer();
            InitiatePayment();
            // InitiateTokenizedPayment();
            GetBanks();
            ValidatePayment();
        }

        public void InitiateNgnTransfer()
        {
            var payload = new TransferPayloadNGN
            {
                account_bank = "044",
                account_number = "0690000031",
                amount = 100,
                callback_url = "https://webhook.site/7b7b7b7b-7b7b-7b7b-7b7b-7b7b7b7b7b7b",
                currency = "NGN",
                narration = "Test transfer",
                reference = Guid.NewGuid().ToString(),
            };
            var response = _flutterwavePayments.InitiateNgnTransfer(payload).Result;
            Console.WriteLine(response.Message);
        }

        public void InitiatePayment()
        {
            var payload = new PaymentPayload
            {
                amount = "100",
                currency = "NGN",
                customer = new Customer
                {
                    email = "ex@example.com",
                    name = "John Doe",
                },
                customization = new Customization
                {
                    title = "Payment for items in cart",
                    description = "Payment for items in cart",
                    logo = "https://assets.piedpiper.com/logo.png"
                },
                tx_ref = Guid.NewGuid().ToString(),
                redirect_url = "https://webhook.site/7b7b7b7b-7b7b-7b7b-7b7b-7b7b7b7b7b7b",
                payment_options = "card"
            };

            var response = _flutterwavePayments.InitiatePayment(payload).Result;
            Console.WriteLine(response.status);
        }

        public void InitiateTokenizedPayment()
        { 
            var payload = new TokenizeChargeModel
            {
                token = "",
                currency = "NGN",
                country = "NG",
                amount = 100,
                email = "ex@example.com",
                first_name = "John",
                last_name = "Doe",
                ip = "",
                narration = "Test payment",
                tx_ref = Guid.NewGuid().ToString()
            };

            var response = _flutterwavePayments.InitiateTokenizedPayment(payload).Result;
            Console.WriteLine(response.status);

        }

        public void GetBanks()
        {
            var response = _flutterwavePayments.GetBanks("NG").Result;
            Console.WriteLine(response.status);
        }
    
        public void ValidatePayment()
        {
            var response = _flutterwavePayments.ValidatePayment(4368404).Result;
            Console.WriteLine(response.status);
        }
    }
}