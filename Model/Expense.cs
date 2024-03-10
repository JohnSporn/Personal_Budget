namespace PersonalBudget.Model
{
    public class Expense
    {
        public int Id { get; set; }
        public string ExpenseName {  get; set; }
        public decimal Amount { get; set; }
        public Finance Finance { get; set; } = null!;
    }
}
