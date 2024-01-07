namespace financial_management_api.Api.Extensions
{
    public static class CustomExtensions
    {
        public static bool IsValidCurrencyCode(this string currencyCode)
        {
            return currencyCode == "USD" || currencyCode == "EUR" || currencyCode == "GBP";
        }
    }
}
