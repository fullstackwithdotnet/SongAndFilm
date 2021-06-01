using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SongAndFilm.Pages.Auth
{
    public class SignOutModel : PageModel
    {
        public void OnGet()
        {
             HttpContext.SignOutAsync().Wait();
        }
    }
}
