using MeetUp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Service.Interfaces
{
    public interface IUserMeetUpsService
    {
        bool AddUserMeetUps(UserMeetUps userMeetUp);
        List<UserMeetUps> GetUsersMeetUps(int id);
        List<UserMeetUps> GetVisitorsForMeetUp(int id);
        bool RemoveUserMeetUp(int userId, int meetUpId);
    }
}
