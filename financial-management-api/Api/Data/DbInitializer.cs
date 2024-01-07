using financial_management_api.Api.Models;

namespace financial_management_api.Api.Data
{
    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Accounts.Any())
            {
                context.Accounts.Add(new Account { /* account properties */ });
            }
            context.SaveChanges();
        }
    }
}
