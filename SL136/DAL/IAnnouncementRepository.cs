namespace IRepository
{
	using System.Collections.Generic;

	using POCO;

	public interface IAnnouncementRepository
	{
		void AddAnnouncement(string text, string date);

		void DeleteAnnouncement(int id);

		List<Announcement> GetAnnouncements();
	}
}