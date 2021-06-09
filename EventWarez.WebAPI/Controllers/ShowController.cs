using EventWarez.Models;
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
            var showService = new ShowService(/*userId*/);
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

        public IHttpActionResult Get(int id)
        {
            ShowService showService = CreateShowService();
            var show = showService.GetShowById(id);
            return Ok(show);
        }

        public IHttpActionResult Put(ShowEdit show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.UpdateShow(show))
                return InternalServerError();

            return Ok();
        }

        [Route("api/Show")]
        public IHttpActionResult Delete(int id)
        {
            {
                var service = CreateShowService();

                if (!service.DeleteShow(id))
                    return InternalServerError();

                return Ok("Note was successfully deleted");
            }
        }

        [HttpPost]
        [Route("api/WorkOrder")]
        public IHttpActionResult PostWorkOrder(WorkOrderCreate workOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new WorkOrderService();

            if (!service.CreateWorkOrder(workOrder))
                return InternalServerError();

            return Ok("Work Order Created");
        }

        [HttpGet]
        [Route("api/WorkOrders")]
        public IHttpActionResult GetWorkOrders()
        {
            var service = new WorkOrderService();
            var workOrders = service.GetWorkOrders();
            return Ok(workOrders);
        }

        [HttpPut]
        [Route("api/WorkOrder")]
        public IHttpActionResult UpdateWorkOrder(WorkOrderEdit workOrderEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new WorkOrderService().UpdateWorkOrder(workOrderEdit);

            if (!service)
                return InternalServerError();

            return Ok("Work Order Updated");
        }

        [HttpDelete]
        [Route("api/WorkOrder")]
        public IHttpActionResult DeleteWorkOrder(int id)
        {
            var service = new WorkOrderService();
            if (!service.DeleteWorkOrder(id))
                return InternalServerError();

            return Ok("Work Order Deleted");
        }

    }


}
