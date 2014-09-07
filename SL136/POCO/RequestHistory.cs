namespace POCO
{
    using System.Collections.Generic;

    public class RequestHistory
    {
        public int ScheduleId { get; set; }

        public string RequestMessage { get; set; }

        public string CourseTitle { get; set; }

        public string CourseDescription { get; set; }

        public string Year { get; set; }

        public string Quarter { get; set; }

        public string Session { get; set; }
    }
}
