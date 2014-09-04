namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class ScheduleController : ApiController
    {
        private readonly ScheduleService service = new ScheduleService(new ScheduleRepository());

        [HttpPost]
        public List<CourseInfo> GetScheduleList(string year, string quarter)
        {
            var service = new ScheduleService(new ScheduleRepository());
            var errors = new List<string>();
            return service.GetScheduleList(year, quarter, ref errors);
        }

        [HttpGet]
        public List<CourseInfo> GetAllSchedules()
        {
            var errors = new List<string>();
            var service = new ScheduleService(new ScheduleRepository());
            return service.GetAllSchedules(ref errors);
        }

        [HttpPost]
        public string AddSchedule(Schedule sch, int day_id, int time_id, int instr_id)
        {
            List<string> errors = new List<string>();
            this.service.AddSchedule(sch, day_id, time_id, instr_id, ref errors);
            return errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string EditSchedule(Schedule sch, int day_id, int time_id, int instr_id)
        {
            List<string> errors = new List<string>();
            this.service.EditSchedule(sch, day_id, time_id, instr_id, ref errors);
            return errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string DeleteSchedule(Schedule sch)
        {
            List<string> errors = new List<string>();
            this.service.DeleteSchedule(sch, ref errors);
            return errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpGet]
        public List<string> GetYears()
        {
            List<string> errors = new List<string>();
            return this.service.GetYears(ref errors);
        }

        [HttpGet]
        public List<string> GetQuarters()
        {
            List<string> errors = new List<string>();
            return this.service.GetQuarters(ref errors);
        }
    }
}