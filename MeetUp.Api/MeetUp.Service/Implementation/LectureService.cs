using MeetUp.Data.Model;
using MeetUp.Repository.Implementation;
using MeetUp.Repository.Interfaces;
using MeetUp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Service.Implementation
{
    public class LectureService : ILectureService
    {
        readonly private ILectureRepository _lectureRepository;

        public LectureService(ILectureRepository lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }

        public Lecture GetLecture(int id)
        {
            return _lectureRepository.GetLecture(id);
        }

        public bool SaveLecture(Lecture lecture)
        {
            return _lectureRepository.AddLecture(lecture);
        }

        //TO DO?
        public bool UpdateLecture(int id)
        {
            throw new NotImplementedException();
        }
    }
}
