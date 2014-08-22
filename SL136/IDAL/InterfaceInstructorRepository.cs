namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface InterfaceInstructorRepository
    {
        void EditGrade(int scheduleId, string studentId, string grade, ref List<string> errors);

        List<Request> GetRequests(int scheduleId, ref List<string> errors);

        void DropStudent(int scheduleId, string studentId, ref List<string> errors);

        void AddTutor(int taId, int courseId, string firstName, string lastName, ref List<string> errors);

        void AssignTutor(int taId, int courseId, ref List<string> errors);

        void DeleteTutor(int taId, ref List<string> errors);
    }
}