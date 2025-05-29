using Microsoft.AspNetCore.Mvc;

namespace PetShop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
