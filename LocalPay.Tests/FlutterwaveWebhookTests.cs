using System.Security.Cryptography;
using System.Text;
using LocalPay.Flutterwave;

namespace LocalPay.Tests;

public class FlutterwaveWebhookTests
{
    private const string SecretHash = "FLWWHSEC-test-secret-hash";
    private static readonly byte[] Body = Encoding.UTF8.GetBytes("""{"event":"charge.completed","data":{}}""");

    [Fact]
    public void Verify_accepts_legacy_verif_hash_equality()
    {
        var ok = FlutterwaveWebhook.Verify(SecretHash, Body, signatureHeaderValue: null, legacyHashHeaderValue: SecretHash);
        ok.Should().BeTrue();
    }

    [Fact]
    public void Verify_rejects_wrong_legacy_verif_hash()
    {
        var ok = FlutterwaveWebhook.Verify(SecretHash, Body, signatureHeaderValue: null, legacyHashHeaderValue: "wrong");
        ok.Should().BeFalse();
    }

    [Fact]
    public void Verify_accepts_valid_hmac_sha256_signature()
    {
        var expected = HmacHex(SecretHash, Body);
        var ok = FlutterwaveWebhook.Verify(SecretHash, Body, signatureHeaderValue: expected, legacyHashHeaderValue: null);
        ok.Should().BeTrue();
    }

    [Fact]
    public void Verify_rejects_tampered_body()
    {
        var expected = HmacHex(SecretHash, Body);
        var tampered = Encoding.UTF8.GetBytes("""{"event":"charge.completed","data":{"hacked":true}}""");
        var ok = FlutterwaveWebhook.Verify(SecretHash, tampered, signatureHeaderValue: expected, legacyHashHeaderValue: null);
        ok.Should().BeFalse();
    }

    [Fact]
    public void Verify_returns_false_when_no_headers_present()
    {
        var ok = FlutterwaveWebhook.Verify(SecretHash, Body, signatureHeaderValue: null, legacyHashHeaderValue: null);
        ok.Should().BeFalse();
    }

    [Fact]
    public void Verify_returns_false_when_secret_hash_missing()
    {
        var ok = FlutterwaveWebhook.Verify(secretHash: "", Body, signatureHeaderValue: "anything", legacyHashHeaderValue: null);
        ok.Should().BeFalse();
    }

    [Fact]
    public void Verify_prefers_hmac_signature_when_both_headers_present()
    {
        var expected = HmacHex(SecretHash, Body);
        var ok = FlutterwaveWebhook.Verify(SecretHash, Body, signatureHeaderValue: expected, legacyHashHeaderValue: "wrong-legacy");
        ok.Should().BeTrue();
    }

    private static string HmacHex(string key, byte[] body)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
        var hash = hmac.ComputeHash(body);
        var sb = new StringBuilder(hash.Length * 2);
        foreach (var b in hash) sb.Append(b.ToString("x2"));
        return sb.ToString();
    }
}
