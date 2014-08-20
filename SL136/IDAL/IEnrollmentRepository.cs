namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IEnrollmentRepository
    {
        List<Enrollment> GetEnrollments(int scheduleId, ref List<string> errors);
    }
}
