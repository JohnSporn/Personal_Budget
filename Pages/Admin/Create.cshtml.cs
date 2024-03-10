using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalBudget.Data;
using PersonalBudget.Data.Repositories;
using PersonalBudget.Model;

namespace PersonalBudget.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IUserRepository userRepository;

        public CreateModel(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyUser = new User();
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            User.Password = passwordHasher.HashPassword(User, User.Password);
            if (await TryUpdateModelAsync<User>(
                emptyUser,
                "user",   // Prefix for form value.
                u => u.FirstName, u => u.LastName, u => u.Email, u => u.Username, u => u.Password))
            {
                await userRepository.CreateUser(User);
                
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
