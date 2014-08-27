namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class StudentController : ApiController
    {
        private readonly StudentService service = new StudentService(new StudentRepository());

        [HttpGet]
        public Student GetStudent(string id)
        {
            List<string> errors = new List<string>();
            return this.service.GetStudent(id, ref errors);
        }

        [HttpPost]
        public string InsertStudent(Student student)
        {
            List<string> errors = new List<string>();
            this.service.InsertStudent(student, ref errors);
            return errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string UpdateStudent(Student student)
        {
            List<string> errors = new List<string>();
            this.service.UpdateStudent(student, ref errors);
            return errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string DeleteStudent(string id)
        {
            List<string> errors = new List<string>();
            this.service.DeleteStudent(id, ref errors);
            return errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpGet]
        public List<Student> GetStudentList()
        {
            List<string> errors = new List<string>();
            return this.service.GetStudentList(ref errors);
        }

        [HttpPost]
        public void SendStudentRequest(string studentId, int scheduleId, string request)
        {
            List<string> errors = new List<string>();
            this.service.SendStudentRequest(studentId, scheduleId, request, ref errors);
        }
    }
}