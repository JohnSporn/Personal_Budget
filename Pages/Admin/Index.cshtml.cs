using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonalBudget.Data;
using PersonalBudget.Data.Repositories;
using PersonalBudget.Model;

namespace PersonalBudget.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        private readonly IUserRepository userRepository;

        public IndexModel(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await userRepository.GetUsers();
        }
    }
}
