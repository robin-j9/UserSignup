using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSignup.Models;

namespace UserSignup.ViewModels
{
    public class DisplayUserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime UserAdded { get; set; }
        public int Id { get; set; }
    
        public DisplayUserViewModel() { }

        public DisplayUserViewModel(int id)
        {
            User user = UserData.GetUserById(id);
            Username = user.Username;
            Email = user.Email;
            UserAdded = user.UserAdded;
        }
    }

}
