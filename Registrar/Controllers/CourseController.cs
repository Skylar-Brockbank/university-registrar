using Microsoft.AspNetCore.Mvc;

namespace Registrar.Controllers
{
  public class CourseController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}