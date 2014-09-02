namespace Service
{
    using System;

    using System.Collections.Generic;

    using System.Text.RegularExpressions;

    using IRepository;

    using POCO;

    public class ScheduleService
    {
        private readonly IScheduleRepository repository;

        public ScheduleService(IScheduleRepository repository)
        {
            this.repository = repository;
            return;
        }

        public List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors)
        {
            return this.repository.GetScheduleList(year, quarter, ref errors);
        }

        public List<CourseInfo> GetAllSchedules(ref List<string> errors)
        {
            return this.repository.GetAllSchedules(ref errors);
        }

        public void AddSchedule(Schedule sch, int sch_day_id, int sch_time_id, int instr_id, ref List<string> errors)
        {
            if (sch == null)
            {
                errors.Add("Add Unsuccessful: Invalid Schedule information");
                return;
            }

            this.CheckSchedule(sch, ref errors, "Add Unsuccessful: ");

            if (errors.Count > 0)
            {
                return;
            }

            if (sch_day_id <= 0)
            {
                errors.Add("Add Unsuccessful: Invalid Schedule Day ID");
                return;
            }

            if (sch_time_id <= 0)
            {
                errors.Add("Add Unsuccessful: Invalid Schedule Time ID");
                return;
            }

            if (instr_id <= 0)
            {
                errors.Add("Add Unsuccessful: Invalid Instructor ID");
                return;
            }

            this.repository.AddSchedule(sch, sch_day_id, sch_time_id, instr_id, ref errors);
        }

        public void DeleteSchedule(Schedule sch, ref List<string> errors)
        {
            if (sch == null)
            {
                errors.Add("Delete Unsuccessful: Invalid schedule information");
                return;
            }
            else
            {
                this.CheckSchedule(sch, ref errors, "Delete Unsuccessful: ");
            }

            this.repository.DeleteSchedule(sch, ref errors);
        }

        public void EditSchedule(Schedule sch, int sch_day_id, int sch_time_id, int instr_id, ref List<string> errors)
        {
            if (sch == null)
            {
                errors.Add("Edit Unsuccessful: Invalid Schedule information");
                return;
            }
            else
            {
                this.CheckSchedule(sch, ref errors, "Edit Unsuccessful: ");
            }

            if (sch_day_id <= 0)
            {
                errors.Add("Edit Unsuccessful: Invalid Schedule Day ID");
                return;
            }

            if (sch_time_id <= 0)
            {
                errors.Add("Edit Unsuccessful: Invalid Schedule Time ID");
                return;
            }

            if (instr_id <= 0)
            {
                errors.Add("Edit Unsuccessful: Invalid Instructor ID");
                return;
            }

            this.repository.EditSchedule(sch, sch_day_id, sch_time_id, instr_id, ref errors);
        }

        private void CheckSchedule(Schedule sch, ref List<string> errors, string state)
        {
            if (sch.ScheduleId <= 0)
            {
                errors.Add(state + "Invalid Schedule ID");
                return;
            }

            Match m = Regex.Match(sch.Year, @"^\d{4}$");
            if (!m.Success)
            {
                errors.Add(state + "Year is formatted incorrectly");
                return;
            }

            m = Regex.Match(sch.Quarter, @"^Fall|Winter|Spring|(Summer\x20[12])$");
            if (!m.Success)
            {
                errors.Add(state + "Quarter is formatted incorrectly");
                return;
            }

            m = Regex.Match(sch.Session, @"^[ABCD]\d{2}$");
            if (!m.Success)
            {
                errors.Add(state + "Sessions is formatted incorrectly");
                return;
            }

            if (sch.Course == null)
            {
                errors.Add(state + "Invalid Course in Schedule Object");
                return;
            }
            else
            {
                this.CheckCourse(sch.Course, ref errors, state);
            }
        }

        private void CheckCourse(Course course, ref List<string> errors, string state)
        {
            if (course.CourseId == null)
            {
                errors.Add(state + "Invalid course ID");
                return;
            }
            else
            {
                Match m = Regex.Match(course.CourseId, @"^[0-9]+$");
                if (!m.Success)
                {
                    errors.Add(state + "Coure ID is formatted incorrectly");
                    return;
                }
            }

            if (course.Title == null || course.Title.Length == 0)
            {
                errors.Add(state + "Invalid Title");
                return;
            }

            if (course.Description == null || course.Description.Length == 0)
            {
                errors.Add(state + "Invalid Course Description");
                return;
            }
        }

        public List<string> GetYears(ref List<string> errors)
        {
            return this.GetYears(ref errors);
        }

        public List<string> GetQuarters(ref List<string> errors)
        {
            return this.GetQuarters(ref errors);
        }
    }
}
