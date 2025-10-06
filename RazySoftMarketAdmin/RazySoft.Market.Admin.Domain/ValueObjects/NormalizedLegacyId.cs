using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RazySoft.Market.Admin.Domain.ValueObjects
{
    /// <summary>
    /// Value object representing a normalized legacy id.
    /// Normalization rules kept simple and deterministic here; project may extend rules per SourceSystem.
    /// </summary>
    public sealed class NormalizedLegacyId
    {
        public string Value { get; }

        private NormalizedLegacyId(string normalized)
        {
            Value = normalized;
        }

        /// <summary>
        /// General normalization: trim + uppercase + collapse spaces.
        /// </summary>
        public static NormalizedLegacyId FromGeneral(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                throw new ArgumentException("raw legacy id cannot be empty", nameof(raw));

            var s = raw.Trim();
            s = Regex.Replace(s, @"\s+", " ");
            s = s.ToUpperInvariant();
            return new NormalizedLegacyId(s);
        }

        /// <summary>
        /// Normalization for phone numbers: keep digits only and remove leading zeros/prefixes if required.
        /// Caller may adjust rules for country codes (this is a simple digit-only normalization).
        /// </summary>
        public static NormalizedLegacyId FromPhone(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                throw new ArgumentException("raw phone cannot be empty", nameof(raw));

            var digits = new string(raw.Where(char.IsDigit).ToArray());
            if (string.IsNullOrEmpty(digits))
                throw new ArgumentException("normalized phone has no digits", nameof(raw));

            // Optionally: remove leading zeros — decision left to integrator.
            // Example: if numbers start with '0' and country code is used, keep as-is for now.
            return new NormalizedLegacyId(digits);
        }

        /// <summary>
        /// Generic factory that tries to decide by a hint (isPhone).
        /// </summary>
        public static NormalizedLegacyId Create(string raw, bool isPhone = false)
        {
            return isPhone ? FromPhone(raw) : FromGeneral(raw);
        }

        public override string ToString() => Value;
    }
}
