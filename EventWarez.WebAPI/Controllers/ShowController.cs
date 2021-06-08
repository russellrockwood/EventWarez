using EventWarez.Models.Show;
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
        private ShowService CreateShowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var showService = new ShowService(userId);
            return showService;
        }

        public IHttpActionResult Post(ShowCreate show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.CreateShow(show))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            ShowService showService = CreateShowService();
            var shows = showService.GetShows();
            return Ok(shows);
        }


    }

    
}
