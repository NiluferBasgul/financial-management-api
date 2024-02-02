namespace financial_management_api.Api.Models
{
    public class Revenue
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
