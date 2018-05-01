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
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public void Add(Address entity)
        {
            addressRepository.NewAddress(entity);
        }

        public Address GetAddressById(int id)
        {
            return addressRepository.GetAddressById(id);
        }

        public void Update(Address address)
        {
            addressRepository.UpdateAddress(address);
        }

        public IEnumerable<Address> GetAll()
        {
            var users = addressRepository.GetAll();
            return users;
        }

        public Address GetById(int id)
        {
            var user = addressRepository.GetAddressById(id);
            return user;
        }

        public Address NewAddress(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
