using MeetUp.Data.Model;
using MeetUp.Data.ViewModel;
using MeetUp.Repository.Implementation;
using MeetUp.Repository.Interfaces;
using MeetUp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Service.Implementation
{
    public class MeetUpService : IMeetUpService
    {
        readonly private IMeetUpRepository _meetUpRepository;
        readonly private IUserService _userService;
        readonly private IAddressService _addressService;
        readonly private ILectureService _lectureService;
        readonly private IUserMeetUpsService _userMeetUpsService;

        public MeetUpService(IMeetUpRepository meetUpRepository, IUserService userService, IAddressService addressService, ILectureService lectureService, IUserMeetUpsService userMeetUpsService)
        {
            _meetUpRepository = meetUpRepository;
            _userService = userService;
            _addressService = addressService;
            _lectureService = lectureService;
            _userMeetUpsService = userMeetUpsService;
        }

        public bool AddVisitorToMeetup(int userId, int meetupId)
        {
            if (_meetUpRepository.AddVisitorToMeetUp(meetupId))
            {
                var meetup = new UserMeetUps { MeetUpId = meetupId, UserId = userId };
                _userMeetUpsService.AddUserMeetUps(meetup);

                return true;
            }

            return false;
        }

        public bool CancelMeetup(int userId, int meetupId)
        {
            if (_meetUpRepository.CancelMeetUp(meetupId))
            {
                _userMeetUpsService.RemoveUserMeetUp(userId, meetupId);

                return true;
            }

            return false;
        }

        public bool CreateMeetUp(MeetupViewModel model)
        {
            Data.Model.MeetUp meetUp = new Data.Model.MeetUp
            {
                Address = new Address { Number = model.HouseNmb, Street = model.Street },
                CurrentVisitorsCount = 0,
                Date = model.Date,
                From = model.From,
                To = model.To,
                Lecture = new Lecture { Lecturer = model.Lecturer, Topic = model.Topic },
                MaxVisitors = model.MaxVisitors,
                Title = model.Title,
                CreatedById = model.CreatorId
            };

            return _meetUpRepository.AddMeetUp(meetUp);
        }

        public Data.Model.MeetUp GetMeetUp(int id)
        {
            return _meetUpRepository.GetMeetUp(id);
        }

        public List<Data.Model.MeetUp> GetMeetUps()
        {
            return _meetUpRepository.GetMeetUps();
        }

        public bool RemoveMeetUp(int id)
        {
            _meetUpRepository.RemoveMeetUp(id);
            return true;
        }

        public bool UpdateMeetUp(Data.Model.MeetUp meetUp)
        {
            return _meetUpRepository.UpdateMeetUp(meetUp);
        }
    }
}
