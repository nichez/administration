using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;

namespace Itc.Am.Common.ViewModels
{
    public class VacationVm
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "Start date is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End date is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EndDate { get; set; }
        public Status? Status { get; set; }
        public string Wait { get; set; }
    }
}
