namespace ScheduleServiceTest
{
    using System;
    using System.Collections.Generic;

    using IRepository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using POCO;
    using Service;

    [TestClass]
    public class ScheduleServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddScheduleErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.AddSchedule(null, 1, 3, 5, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddScheduleErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.AddSchedule(new Schedule { ScheduleId = 1, Year = "2014", Quarter = "Fall", Session = "A01", Course = new Course { CourseId = "11", Title = "some class", CourseLevel = new CourseLevel(), Description = "some description" } }, -1, 3, 5, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddScheduleErrorTest3()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.AddSchedule(new Schedule { ScheduleId = 1, Year = "2014", Quarter = "Fall", Session = "A01", Course = new Course { CourseId = "11", Title = "some class", CourseLevel = new CourseLevel(), Description = "some description" } }, 1, -3, 5, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddScheduleErrorTest4()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.AddSchedule(new Schedule { ScheduleId = 1, Year = "2014", Quarter = "Fall", Session = "A01", Course = new Course { CourseId = "11", Title = "some class", CourseLevel = new CourseLevel(), Description = "some description" } }, 1, 3, -5, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteScheduleErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.DeleteSchedule(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteScheduleErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.DeleteSchedule(new Schedule { ScheduleId = -1, Year = "2014", Quarter = "Fall", Session = "A01", Course = new Course { CourseId = "11", Title = "some class", CourseLevel = new CourseLevel(), Description = "some description" } }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteScheduleErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.DeleteSchedule(new Schedule { ScheduleId = 1, Year = "201444", Quarter = "Fall", Session = "A01", Course = new Course { CourseId = "11", Title = "some class", CourseLevel = new CourseLevel(), Description = "some description" } }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteScheduleErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.DeleteSchedule(new Schedule { ScheduleId = 1, Year = "2014", Quarter = "21321", Session = "A01", Course = new Course { CourseId = "11", Title = "some class", CourseLevel = new CourseLevel(), Description = "some description" } }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteScheduleErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.DeleteSchedule(new Schedule { ScheduleId = 1, Year = "2014", Quarter = "Fall", Session = "AA01", Course = new Course { CourseId = "11", Title = "some class", CourseLevel = new CourseLevel(), Description = "some description" } }, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EditScheduleErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.EditSchedule(null, 1, 3, 5, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EditScheduleErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.EditSchedule(new Schedule { ScheduleId = 1, Year = "2014", Quarter = "Fall", Session = "A01", Course = new Course { CourseId = "11", Title = "some class", CourseLevel = new CourseLevel(), Description = "some description" } }, -1, 3, 5, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EditScheduleErrorTest3()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.EditSchedule(new Schedule { ScheduleId = 1, Year = "2014", Quarter = "Fall", Session = "A01", Course = new Course { CourseId = "11", Title = "some class", CourseLevel = new CourseLevel(), Description = "some description" } }, 1, -3, 5, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EditScheduleErrorTest4()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.EditSchedule(new Schedule { ScheduleId = 1, Year = "2014", Quarter = "Fall", Session = "A01", Course = new Course { CourseId = "11", Title = "some class", CourseLevel = new CourseLevel(), Description = "some description" } }, 1, 3, -5, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }

}
