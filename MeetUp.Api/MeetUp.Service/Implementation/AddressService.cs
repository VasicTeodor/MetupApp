using MeetUp.Data.Model;
using MeetUp.Repository.Implementation;
using MeetUp.Repository.Interfaces;
using MeetUp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Service.Implementation
{
    public class AddressService : IAddressService
    {
        readonly private IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Address GetAddress(int id)
        {
            return _addressRepository.GetAddress(id);
        }

        public bool SaveAddress(Address address)
        {
            return _addressRepository.AddAddress(address);
        }
    }
}
