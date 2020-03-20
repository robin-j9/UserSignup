using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSignup.Models
{
    public class UserData
    {
        private static List<User> users = new List<User>();

        public static void Add(User user)
        {
            users.Add(user);
        }

        //GetAll
        public static List<User> GetUsers()
        {
            return users;
        }

        //GetById
        public static User GetUserById(int id)
        {
            return users.Single(x => x.Id == id);
        }
    }
}
