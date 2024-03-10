using Microsoft.EntityFrameworkCore;
using PersonalBudget.Model;
using System.Collections.Generic;

namespace PersonalBudget.Data
{
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Finance> Finances { get; set; }
    }
}
