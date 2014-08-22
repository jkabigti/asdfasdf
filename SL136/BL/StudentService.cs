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
                errors.Add("Student cannot be null");
            }

            if (student.StudentId.Length < 5)
            {
                errors.Add("Invalid student ID");
            }

            if (validateStudent(student, ref errors))
            {
                this.repository.InsertStudent(student, ref errors);
            }
        }

        public void UpdateStudent(Student student, ref List<string> errors)
        {
            if (student == null)
            {
                errors.Add("Student cannot be null");
            }

            if (string.IsNullOrEmpty(student.StudentId))
            {
                errors.Add("Invalid student id");
            }

            if (student.StudentId.Length < 5)
            {
                errors.Add("Invalid student id");
            }

            if (validateStudent(student, ref errors)) 
            {
                this.repository.UpdateStudent(student, ref errors);
            }
        }

        public Student GetStudent(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid student id");
            }

            return this.repository.GetStudentDetail(id, ref errors);
        }

        public void DeleteStudent(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid student id");
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
                errors.Add("Invalid student id");
            }

            if (enrollments == null)
            {
                errors.Add("Invalid student id");
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

        public void SendStudentRequest(string studentId, int scheduleId, string request, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                errors.Add("Invalid student id");
            }

            if (scheduleId == null)
            {
                errors.Add("Invalid schedule id");
            }

            if (string.IsNullOrEmpty(request))
            {
                errors.Add("Invalid request");
            }

            this.repository.SendStudentRequest(studentId, scheduleId, request, ref errors);

        }

        private bool validateStudent(Student s, ref List<string> errors)
        {
            Match m1 = Regex.Match(s.SSN, @"^\d{3}-\d{2}-\d{4}$");
            if(!m1.Success)
            {
                errors.Add("Invalid SSN");
                return false;
            }

            string regularExpression = "^[a-zA-Z''-'\\s]{1,40}$";

            Match m2 = Regex.Match(s.FirstName, @regularExpression);
            Match m3 = Regex.Match(s.LastName, @regularExpression);
            if(!m2.Success)
            {
                errors.Add("Invalid first name");
                return false;
            }
            if(!m3.Success)
            {
                errors.Add("Invalid last name");
                return false;
            }


            return true;
        }
    }
}
