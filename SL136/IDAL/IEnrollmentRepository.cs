namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IEnrollmentRepository
    {
        List<Enrollment> GetEnrolledStudents(int scheduleId, ref List<string> errors);

        void EnrollSchedule(string studentId, int scheduleId, ref List<string> errors);

        void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors);

        void GetCourse(int sch_id, ref List<string> errors);

        void GetEnrolledSchedules(string student_id, ref List<string> errors);
    }
}
