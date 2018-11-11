using MeetUp.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Service.Interfaces
{
    public interface IMeetUpService
    {
        bool CreateMeetUp(MeetupViewModel meetUp);
        Data.Model.MeetUp GetMeetUp(int id);
        bool UpdateMeetUp(Data.Model.MeetUp meetUp);
        bool RemoveMeetUp(int id);
        bool CancelMeetup(int userId, int meetupId);
        List<Data.Model.MeetUp> GetMeetUps();
        bool AddVisitorToMeetup(int userId, int meetupId);
    }
}
