namespace Web136.Controllers
{
    using System.Web.Mvc;

    public class StudentController : Controller
    {
        public ActionResult Index(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult Edit(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult AddRequest(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult ViewGrade(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult EnrollCourse(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }
    }
}
