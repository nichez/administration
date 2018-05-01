using System.Collections.Generic;
using Itc.Am.Common.Models;

namespace Itc.Am.BL.Interfaces
{
    public interface IUserAddressService
    {
        IEnumerable<UserAddress> GetAllAdd();
        void Add(UserAddress userAddress);
    }
}