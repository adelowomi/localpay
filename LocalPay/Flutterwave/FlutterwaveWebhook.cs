using System;
using System.Security.Cryptography;
using System.Text;

namespace LocalPay.Flutterwave
{
    /// <summary>
    /// Helpers for verifying Flutterwave webhook signatures.
    /// </summary>
    public static class FlutterwaveWebhook
    {
        public const string LegacySignatureHeader = "verif-hash";
        public const string SignatureHeader = "flutterwave-signature";

        /// <summary>
        /// Verify a Flutterwave webhook signature. Supports both the legacy
        /// <c>verif-hash</c> header (plain equality with the dashboard secret hash)
        /// and the newer <c>flutterwave-signature</c> header
        /// (HMAC-SHA256 of the raw request body using the secret hash).
        /// </summary>
        /// <param name="secretHash">The "Secret Hash" configured in the Flutterwave dashboard.</param>
        /// <param name="rawRequestBody">The exact UTF-8 bytes of the raw webhook request body.</param>
        /// <param name="signatureHeaderValue">Value of the <c>flutterwave-signature</c> header, if present.</param>
        /// <param name="legacyHashHeaderValue">Value of the <c>verif-hash</c> header, if present.</param>
        /// <returns><c>true</c> if either signature scheme verifies; otherwise <c>false</c>.</returns>
        public static bool Verify(
            string secretHash,
            byte[] rawRequestBody,
            string? signatureHeaderValue,
            string? legacyHashHeaderValue)
        {
            if (string.IsNullOrEmpty(secretHash)) return false;

            if (!string.IsNullOrEmpty(signatureHeaderValue))
            {
                using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretHash));
                var computed = hmac.ComputeHash(rawRequestBody);
                var expected = ToHex(computed);
                return ConstantTimeEquals(expected, signatureHeaderValue!);
            }

            if (!string.IsNullOrEmpty(legacyHashHeaderValue))
            {
                return ConstantTimeEquals(secretHash, legacyHashHeaderValue!);
            }

            return false;
        }

        private static string ToHex(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        private static bool ConstantTimeEquals(string a, string b)
        {
            if (a.Length != b.Length) return false;
            var diff = 0;
            for (var i = 0; i < a.Length; i++) diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}
