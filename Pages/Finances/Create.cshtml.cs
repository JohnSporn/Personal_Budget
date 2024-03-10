using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalBudget.Data;
using PersonalBudget.Model;

namespace PersonalBudget.Pages.Finances
{
    public class CreateModel : PageModel
    {
        private readonly PersonalBudget.Data.BudgetContext _context;

        public CreateModel(PersonalBudget.Data.BudgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Finance Finance { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Finances.Add(Finance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
