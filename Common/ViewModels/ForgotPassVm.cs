using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Am.Common.ViewModels
{
    public class ForgotPassVm
    {
        public int UserId { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        public string Email { get; set; }
    }
}
