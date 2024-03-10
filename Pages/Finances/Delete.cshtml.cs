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
    public class DeleteModel : PageModel
    {
        private readonly PersonalBudget.Data.BudgetContext _context;

        public DeleteModel(PersonalBudget.Data.BudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Finance Finances { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finances = await _context.Finances.FirstOrDefaultAsync(m => m.Id == id);

            if (finances == null)
            {
                return NotFound();
            }
            else
            {
                Finances = finances;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finances = await _context.Finances.FindAsync(id);
            if (finances != null)
            {
                Finances = finances;
                _context.Finances.Remove(Finances);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
