namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class EnrollmentController : ApiController
    {
        private readonly EnrollmentService service = new EnrollmentService(new EnrollmentRepository());

        private List<string> errors = new List<string>();

        [HttpPost]
        public List<Enrollment> GetEnrolledStudents(int scheduleId)
        {
            return this.service.GetEnrollments(scheduleId, ref this.errors);
        }

    }
}