using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;

namespace Itc.Am.Common.ViewModels
{
    public class AddressVm
    {
        //[ForeignKey("UserAddress")]
        //public int UserAddressId { get; set; }

        //[ForeignKey("UserModel")]
        //public int Id { get; set; }

        //[ForeignKey("Address")]
        //public int AddressId { get; set; }

        //public UserAddress UserAddress { get; set; }

        public int Id { get; set; }

        public int AddressId { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Address is Required:")]
        [DisplayName("Address 1:")]
        public string AddressFirst { get; set; }

        [DisplayName("Address 2:")]
        public string AddressSecond { get; set; }

        [Required(ErrorMessage = "Postal Code is Required:")]
        [DisplayName("Postal Code:")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "City is Required:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is Required:")]
        public string Country { get; set; }
    }
}
