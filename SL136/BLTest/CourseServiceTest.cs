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
    public class CourseServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddPrereqErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.AddPrereq(null, null, ref errors);
        
            //// Assert
            Assert.AreEqual(2, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddPrereqErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.AddPrereq(new Course { CourseId = "11", Title = "some class", CourseLevel = 1, Description = "some description" }, null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddPrereqErrorTest3()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.AddPrereq(null, new Course { CourseId = "11", Title = "some class", CourseLevel = 1, Description = "some description" }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddPrereqErrorTest4()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.AddPrereq(new Course { CourseId = "11", Title = "some class", CourseLevel = 1, Description = "some description" }, new Course { CourseId = "11AAA", Title = "some class", CourseLevel = 2, Description = "some description" }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeletePrereqErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.DeletePrereq(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeletePrereqErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.DeletePrereq(new Course { CourseId = "AA11", Title = "some class", CourseLevel = 1, Description = "some description" }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeletePrereqErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.DeletePrereq(new Course { CourseId = "11", Title = null, CourseLevel = 2, Description = "some description" }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeletePrereqErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.DeletePrereq(new Course { CourseId = "11", Title = "some title", CourseLevel = 2, Description = null }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeletePrereqErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.DeletePrereq(new Course { CourseId = "-11", Title = "some title", CourseLevel = 2, Description = "some description" }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeletePrereqErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.DeletePrereq(new Course { CourseId = "11", Title = "", CourseLevel = 2, Description = "some description" }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeletePrereqErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.DeletePrereq(new Course { CourseId = "11", Title = "some title", CourseLevel = 1, Description = "" }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EditPrereqErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.EditPrereq(null, null, ref errors);

            //// Assert
            Assert.AreEqual(2, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EditPrereqErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.EditPrereq(new Course { CourseId = "11", Title = "some class", CourseLevel = 0, Description = "some description" }, null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EditPrereqErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.EditPrereq(null, new Course { CourseId = "11", Title = "some class", CourseLevel = 0, Description = "some description" }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
