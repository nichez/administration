using Itc.Am.Common.Models;

namespace Itc.Am.DL.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Address NewAddress(Address address);
        Address GetAddressById(int id);
        void UpdateAddress(Address address);
    }
}