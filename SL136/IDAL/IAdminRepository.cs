namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IAdminRepository
    {
        void UpdateAdminInfo(Admin admin, ref List<string> errors);

        Admin GetAdminInfo(int id, ref List<string> errors);
    }
}
