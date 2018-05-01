using System.Collections.Generic;
using Itc.Am.Common.Models;

namespace Itc.Am.BL.Interfaces
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAll();
        void Add(Address address);
        Address GetById(int id);
        void Update(Address address);
    }
}