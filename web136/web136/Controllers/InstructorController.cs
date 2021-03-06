namespace Web136.Controllers
{
    using System.Web.Mvc;

    public class InstructorController : Controller
    {
        public ActionResult Index(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult EditGrade()
        {
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult GetRequests()
        {
            return this.View();
        }

        public ActionResult EnrollStudents()
        {
            return this.View();
        }

        public ActionResult DropStudent()
        {
            return this.View();
        }

        public ActionResult AddTutor()
        {
            return this.View();
        }

        public ActionResult EditTutor()
        {
            return this.View();
        }

        public ActionResult AssignTutor()
        {
            return this.View();
        }

        public ActionResult DeleteTutor()
        {
            return this.View();
        }

        public ActionResult CourseList()
        {
            return this.View();
        }

        public ActionResult InstructorClasses(int id)
        {
            ViewBag.Id = id;
            return this.View();
        }
    }
}
