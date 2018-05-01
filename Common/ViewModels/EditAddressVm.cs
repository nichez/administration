using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Am.Common.ViewModels
{
    public class EditAddressVm
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public string AddressFirst { get; set; }
        public string AddressSecond { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
