using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;
using Itc.Am.DL.Infrastructure;
using Itc.Am.DL.Interfaces;

namespace Itc.Am.DL.Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Address NewAddress(Address address)
        {
            DbContext.Addresses.Add(address);
            DbContext.Commit();

            return address;
        }

        public Address GetAddressById(int id)
        {
            var address = DbContext.Addresses.Where(c => c.AddressId == id).FirstOrDefault();

            return address;
        }

        public void UpdateAddress(Address entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            entity.DateUpdated = DateTime.Now;
            Update(entity);
            DbContext.Commit();
        }

    }
}
