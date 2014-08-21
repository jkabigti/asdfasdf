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

        private List<string> errors = new List<string>();

        [HttpPost]
        public List<Schedule> GetScheduleList(string year, string quarter)
        {
            var service = new ScheduleService(new ScheduleRepository());
            var errors = new List<string>();
            return service.GetScheduleList(year, quarter, ref errors);
        }

        [HttpPost]
        public string AddSchedule(Schedule sch, int day_id, int time_id, int instr_id)
        {
            this.service.AddSchedule(sch, day_id, time_id, instr_id, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string EditSchedule(Schedule sch, int day_id, int time_id, int instr_id)
        {
            this.service.EditSchedule(sch, day_id, time_id, instr_id, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string DeleteSchedule(Schedule sch)
        {
            this.service.DeleteSchedule(sch, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

    }
}