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

        /// <summary>
        /// Create a new Attendee Row
        /// </summary>
        /// <param name="att">This Endpoint Creates an Entirely new Attendee Row in the Attendee Database.</param>
        /// <returns></returns>
        public IHttpActionResult PostAttendee(AttendeeCreate att)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_attendeeService.AddAttendee(att))
                return InternalServerError();

            return Ok("Attendee Row Added to Database");
        }
        /// <summary>
        /// Returns Full List of all Existing Attendees
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAttendeesFull()
        {
            var attendees = _attendeeService.GetAttendees();
            return Ok(attendees);
        }
        /// <summary>
        /// Allows an Attendee to purchase a ticket
        /// </summary>
        /// <param name="ticket">Takes in a Ticket object, defined in the body by Id #, and adds the appropriate Attendee Id to that ticket, removing that ticket from the database.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Returns List of Tickets By Attendee Id.
        /// </summary>
        /// <param name="attId">Insert an Attendee Id into the uri arguments, and return a list of relevant tickets.</param>
        /// <returns></returns>
        public IHttpActionResult GetTicketsByAttendee(int attId)
        {
            AttendeeService service = new AttendeeService();
            var attendees = service.GetTicketByAttendee(attId);
            return Ok(attendees);
        }
    }

}
