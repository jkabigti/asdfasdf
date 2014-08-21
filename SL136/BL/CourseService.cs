namespace Service
{
    using System;

    using System.Collections.Generic;

    using System.Text.RegularExpressions;

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
            if (course == null)
            {
                // Throw error message
                errors.Add("Add Unsuccessful: Invalid course");
                throw new ArgumentException();
            }
            else
            {
                checkCourse(course, ref errors, "Add Unsuccessful: ");
            }
            if(prereq == null)
            {
                // Throw error message
                errors.Add("Add Unsuccessful: Invalid Prereq course");
                throw new ArgumentException();
            }
            else
            {
                checkCourse(prereq, ref errors, "Add Unsuccessful: ");
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
            else
            {
                checkCourse(course, ref errors, "Edit Unsuccessful: ");
            }
            if(prereq == null)
            {
                // Throw error message
                errors.Add("Edit Unsuccessful: Invalid Prereq course");
                throw new ArgumentException();
            }
            else
            {
                checkCourse(prereq, ref errors, "Edit Unsuccessful: ");
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
            else
            {
                checkCourse(course, ref errors, "Delete Unsuccessful: ");
            }
            this.repository.DeletePrereq(course, ref errors);
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
