namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IEnrollmentRepository
    {
        List<Enrollment> GetEnrollments(int scheduleId, ref List<string> errors);

        void EnrollSchedule(string studentId, int scheduleId, ref List<string> errors);

        void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors);
    }
}
