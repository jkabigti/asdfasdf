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

        private List<string> errors = new List<string>();

        [HttpPost]
        public string EditGrade(int scheduleId, string studentId, string grade)
        {
            this.service.EditGrade(scheduleId, studentId, grade, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public List<Request> GetResquests(int scheduleId)
        {
            return this.service.GetRequests(scheduleId, ref this.errors);
        }

        [HttpPost]
        public string DropStudent(int scheduleId, string studentId)
        {
            this.service.DropStudent(scheduleId, studentId, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string AddTutor(int taId, int courseId, string firstName, string lastName)
        {
            this.service.AddTutor(taId, courseId, firstName, lastName, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string AssignTutor(int taId, int courseId)
        {
            this.service.AssignTutor(taId, courseId, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string DeleteTutor(int taId)
        {
            this.service.DeleteTutor(taId, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }


    }
}