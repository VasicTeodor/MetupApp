using MeetUp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Repository.Interfaces
{
    public interface IUserMeetUpsRepository
    {
        bool AddUserMeetUp(UserMeetUps userMeetUps);
        List<UserMeetUps> GetUserMeetUps(int id);
        List<UserMeetUps> GetVisitors(int id);
        bool RemoveUserMeetUp(int id, int meetUpId);
    }
}
