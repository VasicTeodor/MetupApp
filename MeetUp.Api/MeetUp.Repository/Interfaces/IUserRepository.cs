using System;
using System.Collections.Generic;
using System.Text;
using MeetUp.Data.Model;

namespace MeetUp.Repository.Interfaces
{
    public interface IUserRepository
    {
        bool SaveUser(User user);
        void UpdateUser(User user);
        User GetUser(int id);
        User GetUserByUsername(string username);
        List<User> GetUsers();
        bool UsernameExists(string username);
    }
}
