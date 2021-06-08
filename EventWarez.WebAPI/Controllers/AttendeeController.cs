using EventWarez.Models;
using EventWarez.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventWarez.WebAPI.Controllers
{
    public class AttendeeController : ApiController
    {
        private AttendeeService _attendeeService = new AttendeeService();
        public IHttpActionResult PostAttendee(AttendeeCreate att)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_attendeeService.AddAttendee(att))
                return InternalServerError();

            return Ok("Attendee Row Added to Database");
        }

        public IHttpActionResult GetAttendeesFull()
        {
            var attendees = _attendeeService.GetAttendees();
            return Ok(attendees);
        }
    }

}
