using MeetUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using MeetUp.Data.Model;

namespace MeetUp.Repository.Implementation
{
    public class LectureRepository : ILectureRepository
    {
        readonly private MeetUpContext _meetUpContext;

        public LectureRepository(MeetUpContext meetUpContext)
        {
            _meetUpContext = meetUpContext;
        }

        public bool AddLecture(Lecture lecture)
        {
            try
            {
                _meetUpContext.Lectures.Add(lecture);
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);

                return false;
            }

            return true;
        }

        public Lecture GetLecture(int id)
        {
            Lecture lecture = new Lecture();

            try
            {
                lecture = _meetUpContext.Lectures.FirstOrDefault(x => x.Id == id);
            }
            catch(Exception e)
            {
                Trace.WriteLine("Exception: " + e.Message);
            }

            return lecture;
        }
    }
}
