using LocalPay.Flutterwave.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LocalPay.Tests;

public class FlutterwaveSerializationTests
{
    [Fact]
    public void PaymentPayload_serializes_to_snake_case_wire_format()
    {
        var payload = new PaymentPayload
        {
            TxRef = "abc-123",
            Amount = 1500.50m,
            Currency = "NGN",
            RedirectUrl = "https://example.com/return",
            PaymentOptions = "card",
            Customer = new Customer { Email = "a@b.com", Name = "Test User", PhoneNumber = "08000000000" },
            Customizations = new Customization { Title = "Order", Description = "Cart checkout", Logo = "https://example.com/logo.png" }
        };

        var json = JObject.Parse(JsonConvert.SerializeObject(payload));

        json["tx_ref"]!.Value<string>().Should().Be("abc-123");
        json["amount"]!.Value<decimal>().Should().Be(1500.50m);
        json["currency"]!.Value<string>().Should().Be("NGN");
        json["redirect_url"]!.Value<string>().Should().Be("https://example.com/return");
        json["payment_options"]!.Value<string>().Should().Be("card");
        json["customer"]!["email"]!.Value<string>().Should().Be("a@b.com");
        json["customer"]!["phonenumber"]!.Value<string>().Should().Be("08000000000");
        json["customizations"]!["title"]!.Value<string>().Should().Be("Order");
    }

    [Fact]
    public void PaymentPayload_omits_null_optional_fields()
    {
        var payload = new PaymentPayload
        {
            TxRef = "abc",
            Amount = 100m,
            Currency = "NGN",
            RedirectUrl = "https://x.test",
            Customer = new Customer { Email = "a@b.com", Name = "X" }
        };

        var json = JsonConvert.SerializeObject(payload);

        json.Should().NotContain("payment_options");
        json.Should().NotContain("customizations");
    }

    [Fact]
    public void PaymentResponse_deserializes_real_flutterwave_payload()
    {
        const string json = """
        {
          "status": "success",
          "message": "Transaction fetched successfully",
          "data": {
            "id": 4368404,
            "tx_ref": "Links-616626414629",
            "flw_ref": "PeterEkene/FLW270177170",
            "amount": 100,
            "currency": "NGN",
            "charged_amount": 100,
            "app_fee": 1.4,
            "merchant_fee": 0,
            "status": "successful",
            "payment_type": "card",
            "created_at": "2020-07-15T14:31:16.000Z",
            "account_id": 17321,
            "amount_settled": 98.6,
            "card": {
              "first_6digits": "232343",
              "last_4digits": "4567",
              "issuer": "VISA",
              "country": "NG",
              "type": "DEBIT",
              "expiry": "02/23"
            }
          }
        }
        """;

        var parsed = JsonConvert.DeserializeObject<PaymentResponse>(json);

        parsed.Should().NotBeNull();
        parsed!.Status.Should().Be("success");
        parsed.Data.Should().NotBeNull();
        parsed.Data!.Id.Should().Be(4368404L);
        parsed.Data.TxRef.Should().Be("Links-616626414629");
        parsed.Data.Amount.Should().Be(100m);
        parsed.Data.AppFee.Should().Be(1.4m);
        parsed.Data.AmountSettled.Should().Be(98.6m);
        parsed.Data.TransactionStatus.Should().Be("successful");
        parsed.Data.Card!.Last4Digits.Should().Be("4567");
    }

    [Fact]
    public void GetBanksResponse_deserializes_with_long_ids()
    {
        const string json = """
        {
          "status": "success",
          "message": "Banks fetched successfully",
          "data": [
            { "id": 132, "code": "044", "name": "Access Bank" },
            { "id": 133, "code": "058", "name": "GTBank" }
          ]
        }
        """;

        var parsed = JsonConvert.DeserializeObject<GetBanksResponse>(json);

        parsed!.Data.Should().HaveCount(2);
        parsed.Data[0].Id.Should().Be(132L);
        parsed.Data[0].Code.Should().Be("044");
        parsed.Data[1].Name.Should().Be("GTBank");
    }

    [Fact]
    public void TransferResponse_deserializes_snake_case_fields()
    {
        const string json = """
        {
          "status": "success",
          "message": "Transfer Queued Successfully",
          "data": {
            "id": 1933,
            "account_number": "0690000031",
            "bank_code": "044",
            "full_name": "Mercedes Daniel",
            "created_at": "2020-01-20T16:09:34.000Z",
            "currency": "NGN",
            "debit_currency": "NGN",
            "amount": 5500,
            "fee": 45,
            "status": "NEW",
            "reference": "akhlm-pstmnpyot-1170",
            "narration": "test transfer",
            "complete_message": "",
            "requires_approval": 0,
            "is_approved": 1,
            "bank_name": "ACCESS BANK NIGERIA"
          }
        }
        """;

        var parsed = JsonConvert.DeserializeObject<TransferResponse>(json);

        parsed!.Status.Should().Be("success");
        parsed.Data!.Id.Should().Be(1933L);
        parsed.Data.AccountNumber.Should().Be("0690000031");
        parsed.Data.Amount.Should().Be(5500m);
        parsed.Data.Fee.Should().Be(45m);
        parsed.Data.TransferStatus.Should().Be("NEW");
        parsed.Data.BankName.Should().Be("ACCESS BANK NIGERIA");
    }
}
