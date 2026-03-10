using Microsoft.AspNetCore.Mvc;
using StudentActivityPortal.Data;
using StudentActivityPortal.Models;

namespace StudentActivityPortal.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly AppDbContext _context;

        public ActivitiesController(AppDbContext context)
        {
            _context = context;
        }

        // VIEW ALL ACTIVITIES
        public IActionResult Index()
        {
            var activities = _context.Activities.ToList();
            return View(activities);
        }

        // CREATE PAGE
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Activities.Add(activity);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        // EDIT PAGE
        public IActionResult Edit(int id)
        {
            var activity = _context.Activities.Find(id);

            if (activity == null)
                return NotFound();

            return View(activity);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Activity activity)
        {
            _context.Activities.Update(activity);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var activity = _context.Activities.Find(id);

            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // SAVE USER SELECTION (SESSION)
        public IActionResult Select(int id)
        {
            HttpContext.Session.SetInt32("SelectedActivity", id);
            return RedirectToAction("Index");
        }
    }
}