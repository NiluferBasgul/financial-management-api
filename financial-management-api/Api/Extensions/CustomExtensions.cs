namespace financial_management_api.Api.Extensions
{
    /// <summary>
    /// Provides custom extension methods for various functionalities.
    /// </summary>
    public static class CustomExtensions
    {
        /// <summary>
        /// Checks if the provided currency code is valid.
        /// </summary>
        /// <param name="currencyCode">The currency code to validate.</param>
        /// <returns>True if the currency code is valid; otherwise, false.</returns>
        public static bool IsValidCurrencyCode(this string currencyCode)
        {
            // Currently supported currency codes
            var supportedCurrencyCodes = new[] { "USD", "EUR", "GBP" };

            // Check if the provided currency code is in the list of supported codes
            if (supportedCurrencyCodes.Contains(currencyCode))
            {
                return true;
            }

            // Throw an exception for an invalid currency code
            throw new InvalidCurrencyCodeException($"Invalid currency code: {currencyCode}. Supported codes are {string.Join(", ", supportedCurrencyCodes)}.");
        }
    }

    /// <summary>
    /// Exception thrown when an invalid currency code is encountered.
    /// </summary>
    public class InvalidCurrencyCodeException : Exception
    {
        public InvalidCurrencyCodeException(string message) : base(message)
        {
        }
    }
}
