using System;
using System.Collections.Generic;
using System.Text;
using MeetUp.Data.Model;

namespace MeetUp.Repository.Interfaces
{
    public interface ILectureRepository
    {
        bool AddLecture(Lecture lecture);
        Lecture GetLecture(int id);
    }
}
