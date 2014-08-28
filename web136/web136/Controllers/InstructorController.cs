namespace Web136.Controllers
{
    using System.Web.Mvc;

    public class InstructorController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult EditGrade(int scheduleId, string studentId, string grade)
        {
            return this.View();
        }

        public ActionResult GetRequests(int scheduleId)
        {
            return this.View();
        }

        public ActionResult DropStudent(int scheduleId, string studentId)
        {
            return this.View();
        }

        public ActionResult AddTutor(int tutorId, int courseId, string firstName, string lastName)
        {
            return this.View();
        }

        public ActionResult AssignTutor(int tutorId, int courseId)
        {
            return this.View();
        }

        public ActionResult DeleteTutor(int tutorId)
        {
            return this.View();
        }
    }
}
