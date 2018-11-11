using MeetUp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Service.Interfaces
{
    public interface IAddressService
    {
        Address GetAddress(int id);
        bool SaveAddress(Address address);
    }
}
