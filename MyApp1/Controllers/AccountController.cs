using Microsoft.AspNetCore.Mvc;

namespace MyApp1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
