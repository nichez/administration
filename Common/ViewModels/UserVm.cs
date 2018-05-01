using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Am.Common.ViewModels
{
     public class UserVm
    {
        public int UserId { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name Required:")]
        [DisplayName("First Name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name Required:")]
        [DisplayName("Last Name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username Required:")]
        [DisplayName("Username:")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required:")]
        [DataType(DataType.Password)]
        [DisplayName("Password:")]
        [StringLength(30, ErrorMessage = "Less than 30 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Required:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm not matched.")]
        [Display(Name = "Confirm password:")]
        [StringLength(30, ErrorMessage = "Less than 30 characters")]
        public string ConfirmPassword { get; set; }

        public string VCode { get; set; }

        public string RoleName { get; set; }
    }
}
