using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Am.Common.ViewModels
{
    public class EditVm
    {
        public int UserId { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username Required:")]
        [DisplayName("Username:")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "First name Required:")]
        [DisplayName("First Name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name Required:")]
        [DisplayName("Last Name:")]
        public string LastName { get; set; }

        public string RoleName { get; set; }
        
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string VCode { get; set; }
    }
}
