using Microsoft.AspNetCore.Mvc;
using StudentActivityPortal.Models; // <-- this is needed

namespace StudentActivityPortal.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save user to DB
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}