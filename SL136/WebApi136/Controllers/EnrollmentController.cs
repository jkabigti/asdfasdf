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
            return this.service.GetEnrolledStudents(scheduleId, ref this.errors);
        }

        [HttpPost]
        public void EnrollSchedule(string studentId, int scheduleId)
        {
            this.service.EnrollSchedule(studentId, scheduleId, ref this.errors);
        }

        [HttpPost]
        public void DropEnrolledSchedule(string studentId, int scheduleId)
        {
            this.service.DropEnrolledSchedule(studentId, scheduleId, ref this.errors);
        }

    }
}