using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;

namespace Itc.Am.Common.ViewModels
{
    public class AllAddressVm
    {
        public UserAddress UsAddresses { get; set; }
        public Address Addr { get; set; }
        public IEnumerable<UserAddress> UserAddresses { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
