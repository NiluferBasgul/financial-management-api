namespace financial_management_api.Api.Models
{
    public class Budget
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
    }
}
