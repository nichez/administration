using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Am.Common.ViewModels
{
    public class UserLoginVm
    {
        public int UserId { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required:")]
        [DataType(DataType.Password)]
        [DisplayName("Password:")]
        [StringLength(30, ErrorMessage = "Less than 30 characters")]
        public string Password { get; set; }

        public string RoleName { get; set; }

        public string VCode { get; set; }
    }
}
