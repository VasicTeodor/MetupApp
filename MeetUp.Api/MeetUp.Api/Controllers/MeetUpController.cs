using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetUp.Data.ViewModel;
using MeetUp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetUp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MeetUpController : ControllerBase
    {
        private readonly IMeetUpService _meetUpService;

        public MeetUpController(IMeetUpService meetUpService)
        {
            _meetUpService = meetUpService;
        }

        [HttpPost("AddMeetup")]
        public IActionResult AddMeetup(MeetupViewModel meetUp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(meetUp);
            }

            if (!_meetUpService.CreateMeetUp(meetUp))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

        [HttpGet("GetAllMeetups")]
        public IActionResult GetAllMeetups()
        {
            List<Data.Model.MeetUp> meetUps = null;

            meetUps = _meetUpService.GetMeetUps();

            if(meetUps == null)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }

            return Ok(meetUps);
        }

        [HttpGet("GetMeetup")]
        public IActionResult GetMeetup(int id)
        {
            Data.Model.MeetUp meetUp = null;

            meetUp = _meetUpService.GetMeetUp(id);

            if(meetUp == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,"Meetup not found.");
            }

            return Ok(meetUp);
        }

        [HttpPut("GoingToMeetup")]
        public IActionResult GoingToMeetup(AttendanceViewModel model)
        {
            if(!_meetUpService.AddVisitorToMeetup(model.UserId, model.MeetupId))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error while updating meetup");
            }

            return Ok();
        }

        [HttpPut("CancelGoingToMeetup")]
        public IActionResult CancelGoingToMeetup(AttendanceViewModel model)
        {
            if (!_meetUpService.CancelMeetup(model.UserId, model.MeetupId))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error while updating meetup");
            }

            return Ok();
        }

        [HttpPut("UpdateMeetup")]
        public IActionResult UpdateMeetup(Data.Model.MeetUp model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            if (!_meetUpService.UpdateMeetUp(model))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error while updating meetup");
            }

            return Ok();
        }

        [HttpDelete("DeleteMeetup")]
        public IActionResult DeleteMeetup(int id)
        {
            if (!_meetUpService.RemoveMeetUp(id))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error while deleting meetup");
            }

            return Ok();
        }
    }
}