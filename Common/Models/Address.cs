using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Itc.Am.Common.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string AddressFirst { get; set; }
        public string AddressSecond { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime? DateUpdated { get; set; }
        public ICollection<UserModel> Users{ get; set; }
    }
}
