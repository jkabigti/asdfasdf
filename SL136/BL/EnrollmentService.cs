﻿namespace Service
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

        public List<Enrollment> GetEnrolledStudents(int scheduleId, ref List<string> errors)
        {
            return this.repository.GetEnrollments(scheduleId, ref errors);
        }

        public void EnrollSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId) || scheduleId < 0)
            {
                errors.Add("Invalid student id or schedule id");
                throw new ArgumentException();
            }

            List<Enrollment> enrolled = this.repository.GetEnrolledSchedules(studentId, ref errors);
            int courseId = this.repository.GetCourse(scheduleId, ref errors);

            for (Enrollment e in enrolled)
            {
                int id = this.repository.GetCourse(e.ScheduleId);
            }

            this.repository.EnrollSchedule(studentId, scheduleId, ref errors);
        }

        public void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId) || scheduleId < 0)
            {
                errors.Add("Invalid student id or schedule id");
                throw new ArgumentException();
            }

            this.repository.DropEnrolledSchedule(studentId, scheduleId, ref errors);
        }

    }
}
