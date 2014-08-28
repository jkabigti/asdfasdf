namespace Web136.Models
{
    using System.Collections.Generic;

    public class CourseInfo
    {
        public int ScheduleId { get; set; }

        public int CourseId { get; set; }

        public string CourseTitle { get; set; }

        public string CourseDescription { get; set; }

        public string Year { get; set; }

        public string Quarter { get; set; }

        public string Session { get; set; }
    }
}