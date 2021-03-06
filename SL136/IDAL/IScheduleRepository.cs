﻿namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IScheduleRepository
    {
        List<CourseInfo> GetScheduleList(string year, string quarter, ref List<string> errors);

        List<CourseInfo> GetAllSchedules(ref List<string> errors);

        void AddSchedule(Schedule sch, int sch_day_id, int sch_time_id, int instr_id, ref List<string> errors);

        void DeleteSchedule(Schedule sch, ref List<string> errors);

        void EditSchedule(Schedule sch, int sch_day_id, int sch_time_id, int instr_id, ref List<string> errors);

        List<string> GetYears(ref List<string> errors);

        List<string> GetQuarters(ref List<string> errors);

        CourseInfo GetScheduleInfo(int scheduleId, ref List<string> errors);
    }
}
