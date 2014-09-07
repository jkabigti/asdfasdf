namespace Web136.Controllers
{
    using System.Web.Mvc;

    public class AdminController : Controller
    {
        public ActionResult Index(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult CurrentSchedule()
        {
            return this.View();
        }

        public ActionResult AddSchedule()
        {
            return this.View();
        }

        public ActionResult EditSchedule()
        {
            return this.View();
        }

        public ActionResult Announcements()
        {
            return this.View();
        }

        public ActionResult AddAnnouncement()
        {
            return this.View();
        }

        public ActionResult EnrollClass()
        {
            return this.View();
        }

        public ActionResult EditAnnouncement()
        {
            return this.View();
        }
    }
}
