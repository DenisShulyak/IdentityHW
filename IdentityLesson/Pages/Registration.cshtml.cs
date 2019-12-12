using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityLesson.Pages
{
    
    public class RegistrationModel : PageModel
    {
        public UserManager<IdentityUser> userManager;
        public RegistrationModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {

        }
        public async Task OnPostAsync()
        {
            var user = new IdentityUser { Email = Email, UserName = Email };
          var result =  await userManager.CreateAsync(user,Password);
        }
    }
}