namespace Service
{
	using System;
	using System.Collections.Generic;
	using IRepository;
	using POCO;

	public class InstructorService
	{
		private readonly InterfaceInstructorRepository repository;

		public InstructorService(InterfaceInstructorRepository repository)
		{
			this.repository = repository;
		}

		public void EditGrade(int scheduleId, string studentId, string grade, ref List<string> errors)
		{
			if (scheduleId == null) {
				errors.Add("Schedule ID cannot be null");
				throw new ArgumentException();
			}

			if (studentId == null) {
				errors.Add("Student ID cannot be null");
				throw new ArgumentException();
			}

			if (grade == null) {
				errors.Add("Grade cannot be null");
				throw new ArgumentException();
			}

            Match m = Regex.Match(grade, @"^[ABCDF][+-]$");
            if (!m.Success)
            {
                errors.Add("Grade is formatted incorrectly");
                throw new ArgumentException();
            }

			this.repository.EditGrade(scheduleId, studentId, grade, ref errors);
		}

		public List<Request> GetRequests(int scheduleId, ref List<string> errors)
		{
			if (scheduleId == null) {
				errors.Add("Schedule ID cannot be null");
				throw new ArgumentException();
			}

			return this.repository.GetRequests(scheduleId, ref errors);
		}

		public void DropStudent(int scheduleId, string studentId, ref List<string> errors)
		{
			if (scheduleId == null) {
				errors.Add("Schedule ID cannot be null");
				throw new ArgumentException();
			}

			if (studentId == null) {
				errors.Add("Student ID cannot be null");
				throw new ArgumentException();
			}

			this.repository.DropStudent(scheduleId, studentId, ref errors);
		}

		public void AddTutor(int taId, int courseId, string firstName, string lastName, ref List<string> errors)
		{
			if (taId == null) {
				errors.Add("TA ID cannot be null");
				throw new ArgumentException();
			}

			if (courseId == null) {
				errors.Add("Course ID cannot be null");
				throw new ArgumentException();
			}

			if (firstName == null) {
				errors.Add("First name cannot be null");
				throw new ArgumentException();
			}

			if (lastName == null) {
				errors.Add("Last name cannot be null");
				throw new ArgumentException();
			}

			this.repository.AddTutor(taId, courseId, firstName, lastName, ref errors);
		}

		public void AssignTutor(int taId, int courseId, ref List<string> errors)
		{
			if (taId == null) {
				errors.Add("TA ID cannot be null");
				throw new ArgumentException();
			}

			if (courseId == null) {
				errors.Add("Course ID cannot be null");
				throw new ArgumentException();
			}

			this.repository.AssignTutor(taId, courseId, ref errors);
		}

		public void DeleteTutor(int taId, ref List<string> errors)
		{
			if (taId == null) {
				errors.Add("TA ID cannot be null");
				throw new ArgumentException();
			}

			this.repository.DeleteTutor(taId, ref errors);
		}
	}
}
