using Microsoft.AspNetCore.Mvc;
using StudentActivityPortal.Data;
using StudentActivityPortal.Models;

namespace StudentActivityPortal.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDAL _dal;

        public UserController(UserDAL dal)
        {
            _dal = dal;
        }

        // GET: /User
        public IActionResult Index()
        {
            var users = _dal.GetAll();
            return View(users);
        }

        // GET: /User/Create
        public IActionResult Create() => View();

        // POST: /User/Create
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            _dal.Create(user);
            return RedirectToAction("Index");
        }

        // GET: /User/Edit/5
        public IActionResult Edit(int id)
        {
            var user = _dal.GetAll().FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

        // POST: /User/Edit/5
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            _dal.Update(user);
            return RedirectToAction("Index");
        }

        // GET: /User/Delete/5
        public IActionResult Delete(int id)
        {
            _dal.Delete(id);
            return RedirectToAction("Index");
        }
    }
}