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
    public class InstructorServiceTest
    {
        [TestMethod]
        public void EditGradeErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.EditGrade(-1, null, null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void EditGradeErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.EditGrade(100, "A12345", "E", ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void EditGradeErrorTest3()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.EditGrade(100, "A12345", "A*", ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void GetRequestsErrorTest()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.GetRequests(-1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DropStudentErrorTest()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.DropStudent(-1, "A1234", ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DropStudentErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.DropStudent(100, null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void AddTutorErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.AddTutor(-1, -1, null, null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void AddTutorErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.AddTutor(100, -1, "John", "Doe", ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void AddTutorErrorTest3()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.AddTutor(100, 1, null, "Doe", ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void AddTutorErrorTest4()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.AddTutor(100, 1, "John", null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void AssignTutorErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.AssignTutor(1, -1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void AssignTutorErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.AssignTutor(-1, 1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DeleteTutorErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<InterfaceInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.DeleteTutor(-1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
