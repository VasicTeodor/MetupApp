using MeetUp.Data.Model;
using MeetUp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MeetUp.Repository.Implementation
{
    public class MeetUpRepository : IMeetUpRepository
    {
        readonly private MeetUpContext _meetUpContext;

        public MeetUpRepository(MeetUpContext meetUpContext)
        {
            _meetUpContext = meetUpContext;
        }

        public bool AddMeetUp(Data.Model.MeetUp meetUp)
        {
            try
            {
                _meetUpContext.MeetUps.Add(meetUp);
                _meetUpContext.Lectures.Add(meetUp.Lecture);
                _meetUpContext.Addresses.Add(meetUp.Address);
                _meetUpContext.SaveChanges();
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception:" + e.Message);

                return false;
            }

            return true;
        }

        public bool AddVisitorToMeetUp(int id)
        {
            try
            {
                var meetup = _meetUpContext.MeetUps.FirstOrDefault(m => m.Id == id);

                if(meetup.CurrentVisitorsCount >= meetup.MaxVisitors)
                {
                    return false;
                }

                meetup.CurrentVisitorsCount += 1;
                _meetUpContext.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);

                return false;
            }

            return true;
        }

        public bool CancelMeetUp(int id)
        {
            try
            {
                var meetup = _meetUpContext.MeetUps.FirstOrDefault(m => m.Id == id);
                meetup.CurrentVisitorsCount -= 1;
                _meetUpContext.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);

                return false;
            }

            return true;
        }

        public Data.Model.MeetUp GetMeetUp(int id)
        {
            Data.Model.MeetUp meetup = null;

            try
            {
                meetup = _meetUpContext.MeetUps
                    .Include(m => m.Address)
                    .Include(m => m.Lecture)
                    .Include(m => m.Visitors)
                    .FirstOrDefault(m => m.Id == id);
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);
            }

            return meetup;
        }

        public List<Data.Model.MeetUp> GetMeetUps()
        {
            List<Data.Model.MeetUp> meetUps = new List<Data.Model.MeetUp>();

            try
            {
                meetUps = _meetUpContext.MeetUps
                    .Include(m => m.Address)
                    .Include(m => m.Lecture)
                    .Include(m => m.Visitors)
                    .ToList();
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);
            }

            return meetUps;
        }

        public bool RemoveMeetUp(int id)
        {
            try
            {
                _meetUpContext.MeetUps.Remove(_meetUpContext.MeetUps
                    .Include(m => m.Address)
                    .Include(m => m.Lecture)
                    .Include(m => m.Visitors)
                    .FirstOrDefault(x => x.Id == id));
                _meetUpContext.SaveChanges();
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);

                return true;
            }

            return true;
        }

        public bool UpdateMeetUp(Data.Model.MeetUp meetUp)
        {
            try
            {
                var oldMeetup = _meetUpContext.MeetUps
                    .Include(m => m.Address)
                    .Include(m => m.Lecture)
                    .Include(m => m.Visitors)
                    .FirstOrDefault(m => m.Id == meetUp.Id);

                oldMeetup.Lecture.Lecturer = meetUp.Lecture.Lecturer;
                oldMeetup.Lecture.Topic = meetUp.Lecture.Topic;
                oldMeetup.From = meetUp.From;
                oldMeetup.To = meetUp.To;
                oldMeetup.Title = meetUp.Title;
                oldMeetup.Address.Street = meetUp.Address.Street;
                oldMeetup.Address.Number = meetUp.Address.Number;
                oldMeetup.Date = meetUp.Date;
                oldMeetup.MaxVisitors = meetUp.MaxVisitors;

                _meetUpContext.SaveChanges();
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: ", e.Message);

                return false;
            }

            return true;
        }
    }
}
