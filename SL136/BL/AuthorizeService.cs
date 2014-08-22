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
            }

            Match m = Regex.Match(email, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            if(!m.Success)
            {
                errors.Add("Invalid email format");
            }

            return this.repository.Authenticate(email, password, ref errors);
        }
    }
}
