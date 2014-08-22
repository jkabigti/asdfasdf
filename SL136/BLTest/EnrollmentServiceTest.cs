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
        [ExpectedException(typeof(ArgumentException))]
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
        [ExpectedException(typeof(ArgumentException))]
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
        [ExpectedException(typeof(ArgumentException))]
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
    }
}
