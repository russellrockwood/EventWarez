using EventWarez.Data;
using EventWarez.Models;
using EventWarez.Models.Attendee;
using EventWarez.Models.Ticket;
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
        private TicketService CreateTickService()
        {
            var tickService = new TicketService();
            return tickService;
        }

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
        [HttpPut]
        [Route("api/Ticket/Purchase")]
        public IHttpActionResult PurchaseTicket(TicketEdit ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTickService();

            if (!service.AddAttendeeToTicket(ticket))
                return InternalServerError();

            return Ok("Ticket Successfully Purchased.");
        }
        public IHttpActionResult GetTicketsByAttendee(int attId)
        {
            AttendeeService service = new AttendeeService();
            var attendees = service.GetTicketByAttendee(attId);
            return Ok(attendees);
        }
    }

}
