using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Itc.Am.Common.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }
        public string VCode { get; set; }
        public DateTime? DateUpdated { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<WorktimeRecord> WorktimeRecords { get; set; }
        public ICollection<Vacation> Vacations { get; set; }
    }
}
