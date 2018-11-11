using MeetUp.Data.Model;
using MeetUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MeetUp.Repository.Implementation
{
    public class UserMeetUpsRepository : IUserMeetUpsRepository
    {
        readonly private MeetUpContext _meetUpContext;

        public UserMeetUpsRepository(MeetUpContext meetUpContext)
        {
            _meetUpContext = meetUpContext;
        }
        public bool AddUserMeetUp(UserMeetUps userMeetUps)
        {
            try
            {
                _meetUpContext.UserMeetUps.Add(userMeetUps);
                _meetUpContext.SaveChanges();
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);

                return false;
            }

            return true;
        }

        public List<UserMeetUps> GetUserMeetUps(int id)
        {
            List<UserMeetUps> meetups = new List<UserMeetUps>();

            try
            {
                meetups = _meetUpContext.UserMeetUps.Where(m => m.UserId == id).ToList();
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);
            }

            return meetups;
        }

        public List<UserMeetUps> GetVisitors(int id)
        {
            List<UserMeetUps> meetUps = new List<UserMeetUps>();

            try
            {
                meetUps = _meetUpContext.UserMeetUps.Where(m => m.MeetUpId == id).ToList();
            }
            catch (Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);
            }

            return meetUps;
        }

        public bool RemoveUserMeetUp(int id, int meetUpId)
        {
            try
            {
                _meetUpContext.UserMeetUps.Remove(_meetUpContext.UserMeetUps.FirstOrDefault(m => m.MeetUpId == meetUpId && m.UserId == id));
                _meetUpContext.SaveChanges();
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);

                return false;
            }

            return true;
        }
    }
}
