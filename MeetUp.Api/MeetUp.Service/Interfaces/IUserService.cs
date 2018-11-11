using MeetUp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Service.Interfaces
{
    public interface IUserService
    {
        bool AddUser(User user);
        User GetUser(int id);
        User GetUserByUsername(string username);
        bool UsernameExists(string username);
        List<User> GetUsers();
        void UpdateUser(User user);
        bool UserLogin(string username, string password);
    }
}
