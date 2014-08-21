namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class CourseController : ApiController
    {
        private readonly CourseService service = new CourseService(new CourseRepository());

        private List<string> errors = new List<string>();

        [HttpGet]
        public List<Course> GetCourseList()
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            return service.GetCourseList(ref errors);
        }

        [HttpPost]
        public string AddPrereq(Course course, Course prereq)
        {
            this.service.AddPrereq(course, prereq, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string EditPreqreq(Course course, Course prereq)
        {
            this.service.EditPrereq(course, prereq, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string DeletePrereq(Course prereq)
        {
            this.service.DeletePrereq(prereq, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }
        //// you can add more [HttpGet] and [HttpPost] methods as you need
    }
}