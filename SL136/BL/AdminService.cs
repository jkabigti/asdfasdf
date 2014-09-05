namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class AdminService
    {
        private readonly IAdminRepository repository;

        public AdminService(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public void UpdateAdminInfo(Admin admin, ref List<string> errors)
        {
            if( admin == null )
            {
                errors.Add("Admin can't be null");
                return;
            }
            
            if( this.ValidateAdmin(admin, ref errors))
            {
                this.repository.UpdateAdminInfo(admin, ref errors);
            }
        }

        public Admin GetAdminInfo(int id, ref List<string> errors)
        {
            if( id < 0 )
            {
                errors.Add("Invalid admin id");
                return new Admin();
            }

            return this.repository.GetAdminInfo(id, ref errors);
        }

        private bool ValidateAdmin( Admin a, ref List<string> errors)
        {
            if(a.Id < 0)
            {
                errors.Add("Invalid admin id");
                return false;
            }

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(a.Email);
            if (!match.Success)
            {
                errors.Add("Invalid email format");
                return false;
            }

            string regularExpression = "^[a-zA-Z''-'\\s]{1,40}$";

            Match m2 = Regex.Match(a.FirstName, @regularExpression);
            Match m3 = Regex.Match(a.LastName, @regularExpression);
            if (!m2.Success)
            {
                errors.Add("Invalid first name");
                return false;
            }

            if (!m3.Success)
            {
                errors.Add("Invalid last name");
                return false;
            }

            if( a.Password.Length <= 5 )
            {
                errors.Add("Invalid Password");
                return false;
            }

            return true;
        }
    }
}
