namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class EnrollmentService
    {
        private readonly IEnrollmentRepository repository;

        public EnrollmentService(IEnrollmentRepository repository)
        {
            this.repository = repository;
        }

        public List<int> GetEnrolledStudents(int scheduleId, ref List<string> errors)
        {
            if (scheduleId < 0)
            {
                errors.Add("Invalid schedule id.");
            }

            return this.repository.GetEnrolledStudents(scheduleId, ref errors);
        }

        public List<Enrollment> GetEnrolledSchedules(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid student id.");
            }

            return this.repository.GetEnrolledSchedules(id, ref errors);
        }

        public void EnrollSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId) || scheduleId < 0)
            {
                errors.Add("Invalid student id or schedule id.");
            }

            //List<Enrollment> enrolled = this.repository.GetEnrolledSchedules(studentId, ref errors);
            //int courseId = this.repository.GetCourse(scheduleId, ref errors);

            //foreach (Enrollment e in enrolled)
            //{
            //    int id = this.repository.GetCourse(e.ScheduleId, ref errors);
            //    if (courseId == id)
            //    {
            //        this.repository.EnrollSchedule(studentId, scheduleId, ref errors);
            //    }
            //}
            this.repository.EnrollSchedule(studentId, scheduleId, ref errors);
        }

        public void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId) || scheduleId < 0)
            {
                errors.Add("Invalid student id or schedule id.");
            }

            this.repository.DropEnrolledSchedule(studentId, scheduleId, ref errors);
        }

        public int GetCourse(int sch_id, ref List<string> errors)
        {
            if (sch_id < 0)
            {
                errors.Add("Invalid schedule id.");
            }

            return this.repository.GetCourse(sch_id, ref errors);
        }
    }
}
