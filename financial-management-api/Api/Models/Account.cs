namespace financial_management_api.Api.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Balance { get; set; }
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public string Email { get; set; }

    }
}
