namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class AnnouncementController : ApiController
    {
        private readonly AnnouncementService service = new AnnouncementService(new AnnouncementRepository());

        [HttpPost]
        public string AddAnnouncement(Announcement announcement)
        {
            List<string> errors = new List<string>();
            this.service.AddAnnouncement(announcement, ref errors);
            return errors.Count == 0 ? "ok" : "Error Occured: " + errors[errors.Count - 1].ToString();
        }

        [HttpPost]
        public string DeleteAnnouncement(int id)
        {
            List<string> errors = new List<string>();
            this.service.DeleteAnnouncement(id, ref errors);
            return errors.Count == 0 ? "ok" : "Error Occured: " + errors[errors.Count - 1].ToString();
        }

        [HttpGet]
        public List<Announcement> GetAnnouncements()
        {
            List<string> errors = new List<string>();
            return this.service.GetAnnouncements(ref errors);
        }
    }
}