using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Am.Common.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string RoleName { get; set; }
        public UserModel Users { get; set; }
    }
}
