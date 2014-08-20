namespace Service
{
    using System;

    using System.Collections.Generic;

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
            if( sch == null)
            {
                // Throw Errror
                errors.Add("Add Unsuccessful: Invalid Schedule information");
                throw new ArgumentException();
            }
            if(sch_day_id == null)
            {
                // Throw Errror
                errors.Add("Add Unsuccessful: Invalid Schedule Day ID");
                throw new ArgumentException();
            }
            if(sch_time_id == null)
            {
                // Throw Errror
                errors.Add("Add Unsuccessful: Invalid Schedule Time ID");
                throw new ArgumentException();
            }
            if(instr_id == null)
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
            if (sch_day_id == null)
            {
                // Throw Errror
                errors.Add("Edit Unsuccessful: Invalid Schedule Day ID");
                throw new ArgumentException();
            }
            if (sch_time_id == null)
            {
                // Throw Errror
                errors.Add("Edit Unsuccessful: Invalid Schedule Time ID");
                throw new ArgumentException();
            }
            if (instr_id == null)
            {
                // Throw Errror
                errors.Add("Edit Unsuccessful: Invalid Instructor ID");
                throw new ArgumentException();
            }
            this.repository.EditSchedule(sch, sch_day_id, sch_time_id, instr_id, ref errors);
        }
    }
}
