namespace POCO
{
    using System.Collections.Generic;

    public class Enrollment
    {
        public string StudentId { get; set; }

        public int ScheduleId { get; set; }

        public string Grade { get; set; }

        public float GradeValue { get; set; }

        public int CourseId { get; set; }

        public string CourseTitle { get; set; }

        public string CourseDescription { get; set; }

        public string Year { get; set; }

        public string Quarter { get; set; }

        public string Session { get; set; }
    }
}
