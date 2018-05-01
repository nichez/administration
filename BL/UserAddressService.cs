using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.BL.Interfaces;
using Itc.Am.Common.Models;
using Itc.Am.DL.Interfaces;

namespace Itc.Am.BL
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IUserAddressRepository userAddressRepository;

        public UserAddressService(IUserAddressRepository userAddressRepository)
        {
            this.userAddressRepository = userAddressRepository;
        }

        public void Add(UserAddress entity)
        {
            userAddressRepository.NewUserAddress(entity);
        }

        public IEnumerable<UserAddress> GetAllAdd()
        {
            var users = userAddressRepository.GetAll();
            return users;
        }
       
    }
}
