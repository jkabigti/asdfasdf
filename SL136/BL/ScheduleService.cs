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
        }

        public List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors)
        {
            return this.repository.GetScheduleList(year, quarter, ref errors);
        }

        public void AddSchedule(Schedule sch, int sch_day_id, int sch_time_id, int instr_id, ref List<string> errors)
        {
            if(sch == null)
            {
                // Throw Errror
                errors.Add("Add Unsuccessful: Invalid Schedule information");
                throw new ArgumentException();
            }
            else
            {
                checkSchedule(sch, ref errors, "Add Unsuccessful: ");
            }
            
            if(sch_day_id == null || sch_day_id < 0)
            {
                // Throw Errror
                errors.Add("Add Unsuccessful: Invalid Schedule Day ID");
                throw new ArgumentException();
            }
            if(sch_time_id == null || sch_time_id < 0)
            {
                // Throw Errror
                errors.Add("Add Unsuccessful: Invalid Schedule Time ID");
                throw new ArgumentException();
            }
            if(instr_id == null || instr_id < 0)
            {
                // Throw Errror
                errors.Add("Add Unsuccessful: Invalid Instructor ID");
                throw new ArgumentException();
            }
            this.repository.AddSchedule(sch, sch_day_id, sch_time_id, instr_id, ref errors);
        }

        public void DeleteSchedule(Schedule sch, ref List<string> errors)
        {
            if( sch == null )
            {
                errors.Add("Delete Unsuccessful: Invalid schedule information");
                throw new ArgumentException();
            }
            else
            {
                checkSchedule(sch, ref errors, "Delete Unsuccessful: ");
            }
            this.repository.DeleteSchedule(sch, ref errors);
        }

        public void EditSchedule(Schedule sch, int sch_day_id, int sch_time_id, int instr_id, ref List<string> errors)
        {
            if (sch == null)
            {
                // Throw Errror
                errors.Add("Edit Unsuccessful: Invalid Schedule information");
                throw new ArgumentException();
            }
            else
            {
                checkSchedule(sch, ref errors, "Edit Unsuccessful: ");
            }
            if (sch_day_id == null || sch_day_id < 0)
            {
                // Throw Errror
                errors.Add("Edit Unsuccessful: Invalid Schedule Day ID");
                throw new ArgumentException();
            }
            if (sch_time_id == null || sch_time_id < 0)
            {
                // Throw Errror
                errors.Add("Edit Unsuccessful: Invalid Schedule Time ID");
                throw new ArgumentException();
            }
            if (instr_id == null || instr_id < 0)
            {
                // Throw Errror
                errors.Add("Edit Unsuccessful: Invalid Instructor ID");
                throw new ArgumentException();
            }
            this.repository.EditSchedule(sch, sch_day_id, sch_time_id, instr_id, ref errors);
        }

        private void checkSchedule(Schedule sch, ref List<string> errors, string state)
        {
            if (sch.ScheduleId == null || sch.ScheduleId < 0)
            {
                // Throw Error
                errors.Add(state + "Invalid Schedule ID");
                throw new ArgumentException();
            }
            Match m = Regex.Match(sch.Year, @"^\d{4}$");
            if( !m.Success )
            {
                errors.Add(state + "Year is formatted incorrectly");
                throw new ArgumentException();
            }

            m = Regex.Match(sch.Quarter, @"^Fall|Winter|Spring|(Summer\x20[12])$");
            if( !m.Success )
            {
                errors.Add(state + "Quarter is formatted incorrectly");
                throw new ArgumentException();
            }
            m = Regex.Match(sch.Session, @"^[ABCD]\d{2}$");
            if( !m.Success )
            {
                errors.Add(state + "Sessions is formatted incorrectly");
                throw new ArgumentException();
            }
            // Check Year, Quarter, and Session with REGEX--------------
            if (sch.Course == null)
            {
                //Throw Error
                errors.Add(state + "Invalid Course in Schedule Object");
                throw new ArgumentException();
            }
            else
            {
                checkCourse(sch.Course, ref errors, state);
            }
        }

        private void checkCourse(Course course, ref List<string> errors, string state)
        {
            if (course.CourseId == null)
            {
                errors.Add(state + "Invalid course ID");
                throw new ArgumentException();
            }
            else
            {
                Match m = Regex.Match(course.CourseId, @"^[0-9]+$");
                if (!m.Success)
                {
                    errors.Add(state + "Coure ID is formatted incorrectly");
                    throw new ArgumentException();
                }
            }
            if (course.Title == null || course.Title.Length == 0)
            {
                errors.Add(state + "Invalid Title");
                throw new ArgumentException();
            }
            if (course.CourseLevel == null)
            {
                errors.Add(state + "Invalid CourseLevel");
                throw new ArgumentException();
            }
            if (course.Description == null || course.Description.Length == 0)
            {
                errors.Add(state + "Invalid Course Description");
                throw new ArgumentException();
            }
        }
    }
}
