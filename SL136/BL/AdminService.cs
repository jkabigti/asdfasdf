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
            if (admin == null)
            {
                errors.Add("Admin can't be null.");
                return;
            }

            if (this.ValidateAdmin(admin, ref errors))
            {
                this.repository.UpdateAdminInfo(admin, ref errors);
            }
        }

        public Admin GetAdminInfo(int id, ref List<string> errors)
        {
            if (id < 0)
            {
                errors.Add("Invalid admin id.");
                return new Admin();
            }

            return this.repository.GetAdminInfo(id, ref errors);
        }

        private bool ValidateAdmin(Admin a, ref List<string> errors)
        {
            string regularExpression = "^[a-zA-Z''-'\\s]{1,40}$";

            if (string.IsNullOrEmpty(a.FirstName) || string.IsNullOrEmpty(a.LastName))
            {
                errors.Add("First name and Last name can't be empty.");
                return false;
            }

            Match m2 = Regex.Match(a.FirstName, @regularExpression);
            Match m3 = Regex.Match(a.LastName, @regularExpression);
            if (!m2.Success)
            {
                errors.Add("Invalid first name.");
                return false;
            }

            if (!m3.Success)
            {
                errors.Add("Invalid last name.");
                return false;
            }

            if (string.IsNullOrEmpty(a.Email) || string.IsNullOrEmpty(a.Password))
            {
                errors.Add("Invalid email or password.");
                return false;
            }

            bool b = Regex.IsMatch(a.Email, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            if (!b)
            {
                errors.Add("Invalid email.");
                return false;
            }

            if (a.Password.Length <= 5)
            {
                errors.Add("Invalid Password. Must be at least 6 characters long.");
                return false;
            }

            return true;
        }
    }
}
