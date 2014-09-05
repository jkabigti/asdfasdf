namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class AdminController : ApiController
    {
        private readonly AdminService service = new AdminService(new AdminRepository());

        [HttpGet]
        public Admin GetAdminInfo(int adminId)
        {
            List<string> errors = new List<string>();
            return this.service.GetAdminInfo(adminId, ref errors);
        }

        [HttpPost]
        public string UpdateAdminInfo(Admin admin)
        {
            List<string> errors = new List<string>();
            this.service.UpdateAdminInfo(admin, ref errors);
            return errors.Count == 0 ? "ok" : "Error occurred";
        }
    }
}