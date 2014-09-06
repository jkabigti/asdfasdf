namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IAnnouncementRepository
    {
        void AddAnnouncement(Announcement announcement, ref List<string> errors);

        void DeleteAnnouncement(int id, ref List<string> errors);

        List<Announcement> GetAnnouncements(ref List<string> errors);

        Announcement GetAnnouncementById(int id, ref List<string> errors);

        void EditAnnouncement(Announcement announcement, ref List<string> errors);
    }
}