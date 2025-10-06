using System.Text.RegularExpressions;

namespace RazySoft.MarketSync.Core.Utils
{
    public static class LegacyIdHelper
    {
        // Example: combine fk and moein with hyphen and trim zeros if you want
        public static string Normalize(int fkColCode, int moeinCode)
        {
            // simple normalization: "fk-moein"
            return $"{fkColCode}-{moeinCode}";
        }

        // For phone-like or national codes you can add other helpers (not used here)
        public static string NormalizeNationalId(string? raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return string.Empty;
            var digits = Regex.Replace(raw.Trim(), @"\s+", "");
            return digits.ToUpperInvariant();
        }
    }
}
