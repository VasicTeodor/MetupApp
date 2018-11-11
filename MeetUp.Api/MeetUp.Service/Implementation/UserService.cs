using MeetUp.Data.Helpers;
using MeetUp.Data.Model;
using MeetUp.Repository.Implementation;
using MeetUp.Repository.Interfaces;
using MeetUp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Service.Implementation
{
    public class UserService : IUserService
    {
        readonly private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(User user)
        {
            return _userRepository.SaveUser(user);
        }

        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public bool UserLogin(string username, string password)
        {
            User user = null;

            user = _userRepository.GetUserByUsername(username);

            if(user == null)
            {
                return false;
            }

            if (!PasswordHash.Instance.VerifyPassword(user.Password, password))
            {
                return false;
            }

            return true;
        }

        public bool UsernameExists(string username)
        {
            return _userRepository.UsernameExists(username);
        }
    }
}
