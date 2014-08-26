namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ICourseRepository
    {
        List<Course> GetCourseList(ref List<string> errors);

        void AddPrereq(Course course, Course prereq, ref List<string> errors);

        void EditPrereq(Course course, Course prereq, ref List<string> errors);

        void DeletePrereq(Course course, ref List<string> errors);
    }
}
