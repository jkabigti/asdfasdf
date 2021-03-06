namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class InstructorController : ApiController
    {
        private readonly InstructorService service = new InstructorService(new InstructorRepository());

        [HttpPost]
        public string EditGrade(int scheduleId, string studentId, string grade)
        {
            List<string> errors = new List<string>();
            this.service.EditGrade(scheduleId, studentId, grade, ref errors);
            return errors.Count == 0 ? "ok" : "Error Occured: " + errors[errors.Count - 1].ToString();
        }

        [HttpPost]
        public List<Request> GetRequests(int scheduleId)
        {
            List<string> errors = new List<string>();
            return this.service.GetRequests(scheduleId, ref errors);
        }

        [HttpPost]
        public string DropStudent(int scheduleId, string studentId)
        {
            List<string> errors = new List<string>();
            this.service.DropStudent(scheduleId, studentId, ref errors);
            return errors.Count == 0 ? "ok" : "Error Occured: " + errors[errors.Count - 1].ToString();
        }

        [HttpPost]
        public string AddTutor(int tutorId, int courseId, string firstName, string lastName)
        {
            List<string> errors = new List<string>();
            this.service.AddTutor(tutorId, courseId, firstName, lastName, ref errors);
            return errors.Count == 0 ? "ok" : "Error Occured: " + errors[errors.Count - 1].ToString();
        }

        [HttpPost]
        public string AssignTutor(int tutorId, int courseId)
        {
            List<string> errors = new List<string>();
            this.service.AssignTutor(tutorId, courseId, ref errors);
            return errors.Count == 0 ? "ok" : "Error Occured: " + errors[errors.Count - 1].ToString();
        }

        [HttpPost]
        public string DeleteTutor(int tutorId)
        {
            List<string> errors = new List<string>();
            this.service.DeleteTutor(tutorId, ref errors);
            return errors.Count == 0 ? "ok" : "Error Occured: " + errors[errors.Count - 1].ToString();
        }

        [HttpPost]
        public List<CourseInfo> GetInstructorCourse(int instructorId)
        {
            List<string> errors = new List<string>();
            return this.service.GetInstructorCourse(instructorId, ref errors);
        }
    }
}