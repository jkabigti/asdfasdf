namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IEnrollmentRepository
    {
        List<int> GetEnrolledStudents(int scheduleId, ref List<string> errors);

        void EnrollSchedule(string studentId, int scheduleId, ref List<string> errors);

        void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors);

        int GetCourse(int sch_id, ref List<string> errors);

        List<Enrollment> GetEnrolledSchedules(string id, ref List<string> errors);

        List<Enrollment> InstructorCourses(string id, ref List<string> errors);
    }
}
