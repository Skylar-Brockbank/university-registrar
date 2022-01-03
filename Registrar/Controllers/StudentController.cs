using Microsoft.AspNetCore.Mvc;

namespace Registrar.Controllers
{
  public class StudnetController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Student student)
    {
      _db.Students.Add(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}