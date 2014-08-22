namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
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
                return;
			}

			if (announcement.Text.Length == 0)
			{
				errors.Add("Please include text for announcement");
                return;
			}
            
            bool b = Regex.IsMatch(announcement.Date, @"^((0[1-9]|1[012])[-](19|20)\d\d[-](0?[1-9]|[12][0-9]|3[01])(\x20)(0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5[0-9]$)");
            if (!b)
            {
                errors.Add("Announcement date must be formatted as yy-MM-dd HH:mm:ss");
                return;
            }

            this.repository.AddAnnouncement(announcement, ref errors);
        }

        public void DeleteAnnouncement(int id, ref List<string> errors)
        {
            if (id < 0)
            {
                errors.Add("Announcement ID cannot be negative");
                return;
            }
            this.repository.DeleteAnnouncement(id, ref errors);
        }

        public List<Announcement> GetAnnouncements(ref List<string> errors)
        {
            return this.repository.GetAnnouncements(ref errors);
        }
    }
}
