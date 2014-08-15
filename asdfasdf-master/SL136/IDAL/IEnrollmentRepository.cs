namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    class IEnrollmentRepository
    {
        List<Enrollment> GetEnrollments(int scheduleId, ref List<string> errors);
    }
}
