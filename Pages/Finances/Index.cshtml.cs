using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonalBudget.Data;
using PersonalBudget.Model;

namespace PersonalBudget.Pages.Finances
{
    public class IndexModel : PageModel
    {
        private readonly PersonalBudget.Data.BudgetContext _context;

        public IndexModel(PersonalBudget.Data.BudgetContext context)
        {
            _context = context;
        }

        public IList<Finance> Finances { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Finances = await _context.Finances
                .Include(f => f.User).ToListAsync();
        }
    }
}
