using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Am.Common.Models
{
    public enum Status
    {
        Pending,
        Accepted,
        Rejected
    }

    public class Vacation
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EndDate { get; set; }
        public Status? Status { get; set; }
        public DateTime? DateUpdated { get; set; }
        public virtual UserModel Users { get; set; }
    }
}
