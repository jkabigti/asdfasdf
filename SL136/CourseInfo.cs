namespace POCO
{
    using System.Collections.Generic;

    public class CourseInfo
    {
        public int ScheduleID { get; set; }

        public int CourseID { get; set; }

        public string CourseTitle { get; set; }

        public string CourseLevel { get; set; }

        public string CourseDescription { get; set; }

        public string Year { get; set; }

        public string Quarter { get; set; }

        public string Session { get; set; }
    }
}