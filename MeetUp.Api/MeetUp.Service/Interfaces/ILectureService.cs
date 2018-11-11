using MeetUp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Service.Interfaces
{
    public interface ILectureService
    {
        bool SaveLecture(Lecture lecture);
        Lecture GetLecture(int id);
        bool UpdateLecture(int id);
    }
}
