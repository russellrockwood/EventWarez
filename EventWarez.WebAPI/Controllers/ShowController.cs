using EventWarez.Data;
using EventWarez.Models.Show;
using EventWarez.Models.Ticket;
using EventWarez.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventWarez.WebAPI.Controllers
{
    [Authorize]
    public class ShowController : ApiController
    {
        private TicketService CreateTickService()
        {
            var tickService = new TicketService();
            return tickService;
        }
        private ShowService CreateShowService()
        {
            var showService = new ShowService();
            return showService;
        }
        [HttpPost]
        public IHttpActionResult Post(ShowCreate show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.CreateShow(show))
                return InternalServerError();

            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            ShowService showService = CreateShowService();
            var shows = showService.GetShows();
            return Ok(shows);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ShowService showService = CreateShowService();
            var show = showService.GetShowById(id);
            return Ok(show);
        }

        [HttpPut]
        public IHttpActionResult Put(ShowEdit show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.UpdateShow(show))
                return InternalServerError();

            return Ok();
        }

        [HttpPost]
        [Route("api/Show/Ticket")]
        public IHttpActionResult AddTicketsToShow(TicketCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTickService();

            if (!service.CreateTicket(model))
                return InternalServerError();
            return Ok("Ticket Successfully Added To Show");
        }

        
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            {
                var service = CreateShowService();

                if (!service.DeleteShow(id))
                    return InternalServerError();

                return Ok("Note was successfully deleted");
            }
        }


    }

    
}
