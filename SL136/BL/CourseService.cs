namespace Service
{
    using System;

    using System.Collections.Generic;

    using IRepository;

    using POCO;

    public class CourseService
    {
        private readonly ICourseRepository repository;

        public CourseService(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public List<Course> GetCourseList(ref List<string> errors)
        {
            return this.repository.GetCourseList(ref errors);
        }

        public void AddPrereq(Course course, Course prereq, ref List<string> errors)
        {
            if(course == null)
            {
                // Throw error message
                errors.Add("Add Unsuccessful: Invalid course");
                throw new ArgumentException();
            }
            if(prereq == null)
            {
                // Throw error message
                errors.Add("Add Unsuccessful: Invalid Prereq course");
                throw new ArgumentException();
            }

            this.repository.AddPrereq(course, prereq, ref errors);
        }

        public void EditPrereq(Course course, Course prereq, ref List<string> errors)
        {
            if(course == null)
            {
                // Throw error message
                errors.Add("Edit Unsuccessful: Invalid course");
                throw new ArgumentException();
            }
            if(prereq == null)
            {
                // Throw error message
                errors.Add("Edit Unsuccessful: Invalid Prereq course");
                throw new ArgumentException();
            }
            this.repository.EditPrereq(course, prereq, ref errors);
        }

        public void DeletePrereq(Course course, ref List<string> errors)
        {
            if( course == null )
            {
                // Throw error message
                errors.Add("Delete Unsuccessful: Invalid course");
                throw new ArgumentException();
            }
            this.repository.DeletePrereq(course, ref errors);
        }
    }
}
