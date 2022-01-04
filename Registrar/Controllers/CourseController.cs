using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace Registrar.Controllers
{
  public class CourseController : Controller
  {

    private readonly RegistrarContext _db;

    public CourseController(RegistrarContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Course> model = _db.Courses.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]

    public ActionResult Create(Course course)
    {
      _db.Courses.Add(course);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult RazeItToTheGround()
    {
      return View();
    }

    [HttpPost]
    public ActionResult RazeItToTheGround(string output)
    {
      var whatever = output;
      List<Course> courseList = _db.Courses.ToList();
      foreach(Course c in courseList){
        _db.Courses.Remove(c);
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Course Target = _db.Courses
        .Include(c => c.JoinEntities)
        .ThenInclude(join => join.Student)
        .FirstOrDefault(c => c.CourseId == id);
      return View(Target);
    }
  }
}