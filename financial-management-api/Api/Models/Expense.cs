namespace financial_management_api.Api.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid AccountId { get; set; }  // Change the data type to Guid
        public Account? Account { get; set; }

    }
}