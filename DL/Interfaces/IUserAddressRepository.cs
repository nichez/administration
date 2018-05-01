using System.Collections.Generic;
using Itc.Am.Common.Models;

namespace Itc.Am.DL.Interfaces
{
    public interface IUserAddressRepository
    {
        IEnumerable<UserAddress> GetAll();
        void NewUserAddress(UserAddress userAddress);
    }
}