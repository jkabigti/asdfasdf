namespace Service
{
	using System;
	using System.Collections.Generic;
	using IRepository;
	using POCO;

	public class AnnouncementService
	{
		private readonly IAnnouncementRepository repository;

		public AnnouncementService(IAnnouncementRepository repository)
		{
			this.repository = repository;
		}

		public void AddAnnouncement(Announcement announcement, ref List<string> errors)
		{
			if (announcement == null)
			{
				errors.Add("Announcement cannot be null");
				throw new ArgumentException();
			}

			if (announcement.Text.Length == 0)
			{
				errors.Add("Please include text for announcement");
				throw new ArgumentException();
			}

			this.repository.AddAnnouncement(announcement, ref errors);
		}

		public void DeleteAnnouncement(int id, ref List<string> errors) 
		{
			this.repository.DeleteAnnouncement(id, ref errors);
		}

		public List<Announcement> GetAnnouncements(ref List<string> errors) 
		{
			return this.repository.GetAnnouncements(ref errors);
		}
	}
}
