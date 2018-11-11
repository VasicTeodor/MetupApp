using MeetUp.Data.Model;
using MeetUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MeetUp.Repository.Implementation
{
    public class AddressRepository : IAddressRepository
    {
        readonly private MeetUpContext _meetUpContext;

        public AddressRepository(MeetUpContext meetUpContext)
        {
            _meetUpContext = meetUpContext;
        }

        public bool AddAddress(Address address)
        {
            try
            {
                _meetUpContext.Addresses.Add(address);
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);

                return false;
            }

            return true;
        }

        public Address GetAddress(int id)
        {
            Address address = new Address();

            try
            {
                address = _meetUpContext.Addresses.FirstOrDefault(a => a.Id == id);
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);
            }

            return address;
        }
    }
}
