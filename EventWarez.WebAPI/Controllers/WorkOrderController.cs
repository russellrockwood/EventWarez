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
    public class WorkOrderController : ApiController
    {
        //[Authorize]
        //public IHttpActionResult Post(WorkOrderCreate workOrder)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = new WorkOrderService();

        //    if (!service.CreateWorkOrder(workOrder))
        //        return InternalServerError();

        //    return Ok("Work Order Created");
        //}

        //public IHttpActionResult Get()
        //{
        //    var service = new WorkOrderService();
        //    var workOrders = service.GetWorkOrders();
        //    return Ok(workOrders);
        //}
    }
}
