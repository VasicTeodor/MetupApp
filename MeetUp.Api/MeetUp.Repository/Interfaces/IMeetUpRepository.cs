using System;
using System.Collections.Generic;
using System.Text;
using MeetUp.Data.Model;

namespace MeetUp.Repository.Interfaces
{
    public interface IMeetUpRepository
    {
        bool AddMeetUp(Data.Model.MeetUp meetUp);
        List<Data.Model.MeetUp> GetMeetUps();
        Data.Model.MeetUp GetMeetUp(int id);
        bool RemoveMeetUp(int id);
        bool UpdateMeetUp(Data.Model.MeetUp meetUp);
        bool CancelMeetUp(int id);
        bool AddVisitorToMeetUp(int id);
    }
}
