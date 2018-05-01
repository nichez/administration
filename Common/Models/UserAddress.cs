using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Am.Common.Models
{
    public class UserAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public UserModel Users { get; set; }
        public Address Addresses { get; set; }
    }
}
