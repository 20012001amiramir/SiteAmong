using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameWebSiteProject.Pages
{
    public class home_regModel : PageModel
    {
        public string Username { get; set; }      
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Index");
            }
            else 
            {
                Username = HttpContext.Session.GetString("username");
                return Page();
            } 
        }
    }
}
