using Microsoft.Extensions.Configuration.UserSecrets;

namespace PersonalBudget.Model
{
    public class Finance
    {
        public int Id { get; set; }
        public decimal Income { get; set; }
        public decimal Savings { get; set; }
        public decimal Balance { get; set; }
        public int UserId {  get; set; } 
        public User User { get; set; } = null!;
        public ICollection<Expense> Expenses {  get; set; } = new List<Expense>();
    }
}
