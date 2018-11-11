using MeetUp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Repository.Interfaces
{
    public interface IAddressRepository
    {
        bool AddAddress(Address address);
        Address GetAddress(int id);
    }
}
