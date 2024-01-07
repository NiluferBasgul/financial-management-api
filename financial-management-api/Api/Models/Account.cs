namespace financial_management_api.Api.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal? Balance { get; set; }
    }
}
