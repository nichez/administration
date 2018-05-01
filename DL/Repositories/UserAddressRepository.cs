using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;
using Itc.Am.DL.Infrastructure;
using Itc.Am.DL.Interfaces;

namespace Itc.Am.DL.Repositories
{
    public class UserAddressRepository : RepositoryBase<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void NewUserAddress(UserAddress userAddress)
        {
            DbContext.UserAddresses.Add(userAddress);
            DbContext.Commit();
        }

        public new IEnumerable<UserAddress> GetAll()
        {
            var address = DbContext.UserAddresses.ToList();
            return address;
        }
    }
}
