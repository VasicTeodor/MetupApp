using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MeetUp.Data.Helpers;
using MeetUp.Data.Model;
using MeetUp.Repository.Interfaces;

namespace MeetUp.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        readonly private MeetUpContext _meetUpContext;

        public UserRepository(MeetUpContext meetUpContext)
        {
            _meetUpContext = meetUpContext;
        }

        public User GetUser(int id)
        {
            User user = new User();

            try
            {
                user = _meetUpContext.Users.FirstOrDefault(x => x.Id == id);
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);
            }

            return user;
        }

        public User GetUserByUsername(string username)
        {
            User user = new User();

            try
            {
                user = _meetUpContext.Users.FirstOrDefault(x => x.Username.ToLower().Equals(username.ToLower()));
            }
            catch (Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);
            }

            return user;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            try
            {
                users = _meetUpContext.Users.ToList();
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception :" + e.Message);
            }

            return users;
        }

        public bool SaveUser(User user)
        {
            try
            {
                var newUser = user;
                newUser.Password = PasswordHash.Instance.GenerateHash(user.Password);

                _meetUpContext.Users.Add(newUser);
                _meetUpContext.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.WriteLine("Exception:" + e.Message);

                return false;
            }

            return true;
        }

        public void UpdateUser(User user)
        {
            try
            {
                var updUser = _meetUpContext.Users.FirstOrDefault(u => u.Id == user.Id);
                updUser.Name = user.Name;
                updUser.Surname = user.Surname;
                updUser.Email = user.Email;
                updUser.Password = user.Password;
                _meetUpContext.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);
            }
        }

        public bool UsernameExists(string username)
        {
            bool exists = false;
            try
            {
                exists = _meetUpContext.Users.Any(u => u.Username.ToLower().Equals(username.ToLower()));
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);
            }

            return exists;
        }
    }
}
