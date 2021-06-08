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
    public class TicketController : ApiController
    {
        private TicketService _ticketService = new TicketService();
        public IHttpActionResult PostTicket(TicketCreate ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_ticketService.CreateTicket(ticket))
                return InternalServerError();

            return Ok("Ticket(s) properly added.");
        }

        public IHttpActionResult GetAllTickets()
        {
            var tickets = _ticketService.GetTickets();
            return Ok(tickets);
        }
    }
}
