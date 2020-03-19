using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserSignup.Models;

namespace UserSignup.ViewModels
{
    public class AddUserViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "Name must contain alphabetic characters and spaces only")]
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Verify Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string VerifyPassword { get; set; }
        public DateTime UserAdded { get; set; }
        public int Id { get; set; }

        public User CreateUser()
        {
            return new User
            {
                Username = Username,
                Email = Email,
                Password = Password,
            };
        }
    }
}
