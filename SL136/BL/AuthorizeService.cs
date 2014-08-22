namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class AuthorizeService
    {
        private readonly IAuthorizeRepository repository;

        public AuthorizeService(IAuthorizeRepository repository)
        {
            this.repository = repository;
        }

        public Logon Authenticate(string email, string password, ref List<string> errors)
        {

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                errors.Add("Invalid email or password.");
                return new Logon {UserName = email, Password = password, Id = "1", Role = "TestRole"};
            }

            bool b = Regex.IsMatch(email, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            if(!b)
            {
                errors.Add("Invalid email format");
                return new Logon { UserName = email, Password = password, Id = "1", Role = "TestRole" };
            }

            return this.repository.Authenticate(email, password, ref errors);
        }
    }
}
