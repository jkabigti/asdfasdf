namespace ServiceTest
{
    using System;
    using System.Collections.Generic;

    using IRepository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using POCO;
    using Service;

    [TestClass]
    public class EnrollmentServiceTest
    {
        [TestMethod]
        public void GetEnrolledStudentsTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IEnrollmentRepository>();
            var enrollmentService = new EnrollmentService(mockRepository.Object);

            //// Act
            enrollmentService.GetEnrolledStudents(-1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void GetEnrolledSchedulesTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IEnrollmentRepository>();
            var enrollmentService = new EnrollmentService(mockRepository.Object);

            //// Act
            enrollmentService.GetEnrolledSchedules(string.Empty, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void EnrollScheduleTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IEnrollmentRepository>();
            var enrollmentService = new EnrollmentService(mockRepository.Object);

            //// Act
            enrollmentService.EnrollSchedule(string.Empty, -1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DropEnrolledScheduleTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IEnrollmentRepository>();
            var enrollmentService = new EnrollmentService(mockRepository.Object);

            //// Act
            enrollmentService.EnrollSchedule(string.Empty, -1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void GetCourseErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IEnrollmentRepository>();
            var enrollmentService = new EnrollmentService(mockRepository.Object);

            //// Act
            enrollmentService.GetCourse(-1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
