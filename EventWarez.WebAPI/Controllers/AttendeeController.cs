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
    [Authorize]
    /// <summary>
    /// Allows Access to All Attendee-Side Functions
    /// </summary>
    public class AttendeeController : ApiController
    {
        private TicketService CreateTickService()
        {
            var tickService = new TicketService();
            return tickService;
        }

        private AttendeeService _attendeeService = new AttendeeService();
        private TicketService _ticketService = new TicketService();
        /// <summary>
        /// Create a new Attendee Row
        /// </summary>
        /// <param name="att">This Endpoint Creates an Entirely new Attendee Row in the Attendee Database.</param>
        /// <returns>Success Message.</returns>
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
        /// <returns>All current Attendee Rows.</returns>
        public IHttpActionResult GetAttendeesFull()
        {
            var attendees = _attendeeService.GetAttendees();
            return Ok(attendees);
        }
        /// <summary>
        /// Allows an Attendee to purchase a ticket
        /// </summary>
        /// <param name="ticket">Takes in a Ticket object, defined in the body by Id #, and adds the appropriate Attendee Id to that ticket.</param>
        /// <returns>Success Message.</returns>
        [HttpPut]
        [Route("api/Ticket/Purchase")]

        public IHttpActionResult PurchaseTicket(TicketEdit ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTickService();

            if (!service.AddAttendeeToTicket(ticket))
                return BadRequest("Show Is Sold Out");

            return Ok("Ticket Successfully Purchased.");
        }
        /// <summary>
        /// Returns List of Tickets By Attendee Id.
        /// </summary>
        /// <param name="attId">Insert an Attendee Id into the uri arguments, and return a list of relevant tickets.</param>
        /// <returns>Attendee associated with Id input.</returns>
        [Route("api/GetbyAttid")]
        public IHttpActionResult GetTicketsByAttendee(int attId)        {
            
            var attendees = _attendeeService.GetTicketByAttendee(attId);
            return Ok(attendees);
        }

        /// <summary>
        /// Use to Remove an attendee row from the Database
        /// </summary>
        /// <param name="attId">Takes an Attendee Id as a URI parameter</param>
        /// <returns>Success Message.</returns>
        [Route("api/DeleteAttendee")]
            public IHttpActionResult DeleteAttendee(int attId)
        {
            if (!_attendeeService.DeleteAttendee(attId))
            {
                return InternalServerError();
            }

            return Ok("Successfully Deleted Attendee!");
        }
        /// <summary>
        /// Use to Remove an Ticket row from the Database
        /// </summary>
        /// <param name="tickId">Takes a Ticket Id as a URI parameter</param>
        /// <returns>Success Message.</returns>
        [Route("api/Ticket/Delete")]
        public IHttpActionResult DeleteTicket(int tickId)
        {
            if (!_ticketService.DeleteTicket(tickId))
            {
                return InternalServerError();
            }

            return Ok("Successfully Deleted Attendee!");
        }
    }

}
