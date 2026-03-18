using Microsoft.AspNetCore.Mvc;
using StudentActivityPortal.Data;
using StudentActivityPortal.Models;


public class ActivitiesController : Controller
{

    private readonly ActivityDAL _dal;

    public ActivitiesController(ActivityDAL dal)
    {
        _dal = dal;
    }

    public IActionResult Index()
    {
        var activities = _dal.GetAll();

        int? selectedId = HttpContext.Session.GetInt32("SelectedActivityId");
        ViewBag.SelectedActivityId = selectedId;

        return View(activities);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Activity activity)
    {
        _dal.Create(activity);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var activity = _dal.GetById(id);
        return View(activity);
    }

    [HttpPost]
    public IActionResult Edit(Activity activity)
    {
        _dal.Update(activity);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _dal.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        // Store selected activity in session
        HttpContext.Session.SetInt32("SelectedActivityId", id);

        var activity = _dal.GetById(id);
        return View(activity);
    }
}