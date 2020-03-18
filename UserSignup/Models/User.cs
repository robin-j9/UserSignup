using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSignup.Models
{
    public class User
    {
        private static int nextUserId = 1;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime UserAdded { get; set; }
        public int Id { get; set; }

        public User() 
        {
            Id = nextUserId;
            nextUserId++;
            UserAdded = DateTime.Now;
        }
        public bool NameIsCorrectLength(User user)
        {
            return user.Username.Length > 4 && user.Username.Length < 16;
        }

        public bool NameContainsOnlyLetters(User user)
        {
            return user.Username.All(Char.IsLetter);
        }
    }
}
