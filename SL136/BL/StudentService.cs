namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class StudentService
    {
        private readonly IStudentRepository repository;

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public void InsertStudent(Student student, ref List<string> errors)
        {
            if (student == null)
            {
                errors.Add("Student cannot be null.");
                return;
            }

            if (student.StudentId.Length < 5)
            {
                errors.Add("Invalid student ID.");
                return;
            }

            if (this.ValidateStudent(student, ref errors))
            {
                this.repository.InsertStudent(student, ref errors);
            }
        }

        public void UpdateStudent(Student student, ref List<string> errors)
        {
            if (student == null)
            {
                errors.Add("Student cannot be null.");
                return;
            }

            if (string.IsNullOrEmpty(student.StudentId))
            {
                errors.Add("Invalid student id.");
                return;
            }

            if (string.IsNullOrEmpty(student.Email) || string.IsNullOrEmpty(student.Password))
            {
                errors.Add("All field must be filled.");
                return;
            }

            if (student.StudentId.Length < 7)
            {
                errors.Add("Invalid student id.");
                return;
            }

            bool b = Regex.IsMatch(student.Email, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            if (!b)
            {
                errors.Add("Invalid email.");
                return;
            }

            if (student.Password.Length <= 5)
            {
                errors.Add("Invalid Password. Must be at least 6 characters long.");
                return;
            }

            if (this.ValidateStudent(student, ref errors))
            {
                this.repository.UpdateStudent(student, ref errors);
            }
        }

        public Student GetStudent(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid student id.");
                return new Student { };
            }

            return this.repository.GetStudentDetail(id, ref errors);
        }

        public void DeleteStudent(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid student id.");
                return;
            }

            this.repository.DeleteStudent(id, ref errors);
        }

        public List<Student> GetStudentList(ref List<string> errors)
        {
            return this.repository.GetStudentList(ref errors);
        }

        public float CalculateGpa(string studentId, List<Enrollment> enrollments, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                errors.Add("Invalid student id.");
                return 0.0f;
            }

            if (enrollments == null)
            {
                errors.Add("Invalid student id.");
                return 0.0f;
            }

            if (enrollments.Count == 0)
            {
                return 0.0f;
            }

            var sum = 0.0f;

            foreach (var enrollment in enrollments)
            {
                sum += enrollment.GradeValue;
            }

            return sum / enrollments.Count;
        }

        public void SendStudentRequest(Request request, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(request.StudentId))
            {
                errors.Add("Invalid student id.");
                return;
            }

            if (request.ScheduleId <= 0)
            {
                errors.Add("Invalid schedule id.");
                return;
            }

            if (string.IsNullOrEmpty(request.RequestMessage))
            {
                errors.Add("Invalid request.");
                return;
            }

            this.repository.SendStudentRequest(request.StudentId, request.ScheduleId, request.RequestMessage, ref errors);
        }

        private bool ValidateStudent(Student s, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(s.SSN) || string.IsNullOrEmpty(s.FirstName) || string.IsNullOrEmpty(s.LastName))
            {
                errors.Add("All field must be filled.");
                return false;
            }

            Match m1 = Regex.Match(s.SSN, @"^\d{3}-\d{2}-\d{4}$");
            if (!m1.Success)
            {
                errors.Add("Invalid SSN.");
                return false;
            }

            string regularExpression = "^[a-zA-Z''-'\\s]{1,40}$";

            Match m2 = Regex.Match(s.FirstName, @regularExpression);
            Match m3 = Regex.Match(s.LastName, @regularExpression);
            if (!m2.Success)
            {
                errors.Add("Invalid first name.");
                return false;
            }

            if (!m3.Success)
            {
                errors.Add("Invalid last name.");
                return false;
            }

            return true;
        }
    }
}
