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

        private List<string> errors = new List<string>();

        [HttpPost]
        public string AddAnnouncement(Announcement announcement)
        {
            this.service.AddAnnouncement(announcement, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string DeleteAnnouncement(int id)
        {
            this.service.DeleteAnnouncement(id, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpGet]
        public List<Announcement> GetAnnouncements()
        {
            return this.service.GetAnnouncements(ref this.errors);
        }
    }
}