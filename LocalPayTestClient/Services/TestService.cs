using LocalPay.Baxi;
using LocalPayTestClient.Services.Abstraction;

namespace LocalPayTestClient.Services
{
    public class TestService : ITestService
    {

        private readonly IBaxiPayments _baxiService;

        public TestService(IBaxiPayments baxiService)
        {
            _baxiService = baxiService;
        }

        public void InitiateTest()
        {
           GetBalance();   
           GetBillerCategory(); 
            Console.WriteLine("If this shows up, the test service is working!");
        }

        private void GetBalance()
        {
            var balance = _baxiService.GetBalance().Result;
            Console.WriteLine("Balance: " + balance.Data.Balance);
        }

        private void GetBillerCategory()
        {
            var billerCategory = _baxiService.GetBillerCategory().Result;
            Console.WriteLine("Biller Category: " + billerCategory.Data[0].Name);
        }

        

    }
}