using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalBudget.Data;
using PersonalBudget.Model;

namespace PersonalBudget.Pages.Finances
{
    public class EditModel : PageModel
    {
        private readonly PersonalBudget.Data.BudgetContext _context;

        public EditModel(PersonalBudget.Data.BudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Finance Finance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finance =  await _context.Finances.FirstOrDefaultAsync(m => m.Id == id);
            if (finance == null)
            {
                return NotFound();
            }
            Finance = finance;
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Finance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancesExists(Finance.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FinancesExists(int id)
        {
            return _context.Finances.Any(e => e.Id == id);
        }
    }
}
