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
    public class AnnouncementServiceTest
    {
        [TestMethod]
        public void AddAnnouncementErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IAnnouncementRepository>();
            var announcementService = new AnnouncementService(mockRepository.Object);

            //// Act
            announcementService.AddAnnouncement(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void AddAnnouncementErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IAnnouncementRepository>();
            var announcementService = new AnnouncementService(mockRepository.Object);
            var announcement = new Announcement { Text = string.Empty };

            //// Act
            announcementService.AddAnnouncement(announcement, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void AddAnnouncementErrorTest3()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IAnnouncementRepository>();
            var announcementService = new AnnouncementService(mockRepository.Object);
            var announcement = new Announcement { Text = "test", Date = "2014-08-20 00:00:00" };

            //// Act
            announcementService.AddAnnouncement(announcement, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DeleteAnnouncementErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IAnnouncementRepository>();
            var announcementService = new AnnouncementService(mockRepository.Object);

            //// Act
            announcementService.DeleteAnnouncement(-1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
