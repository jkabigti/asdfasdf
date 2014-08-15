namespace IRepository
{
	using System.Collections.Generic;

	using POCO;

	public interface InterfaceInstructorRepository
	{
		void EditGrade(int scheduleId, string studentId, string grade);

		List<Request> GetRequests(int scheduleId);

		void DropStudent(int scheduleId, string studentId);

		void AddTutor(int taId, int courseId, string firstName, string lastName);

		void AssignTutor(int taId, int courseId);

		void DeleteTutor(int taId);
	}
}