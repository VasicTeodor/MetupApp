using MeetUp.Data.Model;
using MeetUp.Repository.Implementation;
using MeetUp.Repository.Interfaces;
using MeetUp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Service.Implementation
{
    public class UserMeetUpsService : IUserMeetUpsService
    {
        readonly private IUserMeetUpsRepository _userMeetUpsRepository;

        public UserMeetUpsService(IUserMeetUpsRepository userMeetUpsRepository)
        {
            _userMeetUpsRepository = userMeetUpsRepository;
        }

        public bool AddUserMeetUps(UserMeetUps userMeetUp)
        {
            return _userMeetUpsRepository.AddUserMeetUp(userMeetUp);
        }

        public List<UserMeetUps> GetUsersMeetUps(int id)
        {
            return _userMeetUpsRepository.GetUserMeetUps(id);
        }

        public List<UserMeetUps> GetVisitorsForMeetUp(int id)
        {
            return _userMeetUpsRepository.GetVisitors(id);
        }

        public bool RemoveUserMeetUp(int userId, int meetUpId)
        {
            return _userMeetUpsRepository.RemoveUserMeetUp(userId, meetUpId);
        }
    }
}
