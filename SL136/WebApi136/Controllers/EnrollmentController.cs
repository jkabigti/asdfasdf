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

        [HttpPost]
        public List<Enrollment> GetEnrolledSchedules(string id)
        {
            List<string> errors = new List<string>();
            return this.service.GetEnrolledSchedules(id, ref errors);
        }

        [HttpPost]
        public List<int> GetEnrolledStudents(int scheduleId)
        {
            List<string> errors = new List<string>();
            return this.service.GetEnrolledStudents(scheduleId, ref errors);
        }

        [HttpPost]
        public void EnrollSchedule(string studentId, int scheduleId)
        {
            List<string> errors = new List<string>();
            this.service.EnrollSchedule(studentId, scheduleId, ref errors);
        }

        [HttpPost]
        public void DropEnrolledSchedule(string studentId, int scheduleId)
        {
            List<string> errors = new List<string>();
            this.service.DropEnrolledSchedule(studentId, scheduleId, ref errors);
        }

        [HttpPost]
        public int GetCourse(int scheduleId)
        {
            List<string> errors = new List<string>();
            return this.service.GetCourse(scheduleId, ref errors);
        }
    }
}