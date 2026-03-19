using Microsoft.AspNetCore.Mvc;

namespace StudentActivityPortal.Controllers
{
    public class HomeController : Controller
    {
        // Store the user's name temporarily (could use session if you want persistence)
        [HttpGet]
        public IActionResult Index()
        {
            // Optionally, you could pass a model here
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Message = $"Welcome, {name}!";
            }
            else
            {
                ViewBag.Message = "Please enter your name.";
            }

            ViewBag.Name = name;
            return View();
        }
    }
}