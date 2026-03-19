using Microsoft.AspNetCore.Mvc;

namespace StudentActivityPortal.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}