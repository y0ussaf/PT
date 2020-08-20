using System;
using System.Text.RegularExpressions;

namespace Subscription.Domain
{
    public class User
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public User(Guid id,string name,string email)
        {
            if (!EmailRegex.IsMatch(email))
            {
                throw new Exception("invalid email");
            }
            Name = name;
            Email = email;
            Id = id;
        }
        protected User()
        {
        }



    }
}