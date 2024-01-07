namespace financial_management_api.Api.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
