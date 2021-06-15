using EventWarez.Data;
using EventWarez.Models;
using EventWarez.Models.Show;
using EventWarez.Models.Ticket;
using EventWarez.Services;
using System.Linq;
using System.Web.Http;

namespace EventWarez.WebAPI.Controllers
{
    /// <summary>
    /// Access to Venue-Side Functionality
    /// </summary>
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

        /// <summary>
        /// Allows User to Post a new Show Object to the database
        /// </summary>
        /// <param name="show">Takes in show properties and adds them to the database.</param>
        /// <returns>Success Message</returns>
        [HttpPost]
        public IHttpActionResult Post(ShowCreate show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.CreateShow(show))
                return InternalServerError();

            return Ok("Show Successfully Added!");
        }
        /// <summary>
        /// Return a List of All Shows
        /// </summary>
        /// <returns>All Current Shows in Database.</returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            ShowService showService = CreateShowService();
            var shows = showService.GetShows();
            return Ok(shows);
        }
        /// <summary>
        /// Returns one show by ShowId
        /// </summary>
        /// <param name="id">Takes a ShowId number as a URI parameter, and returns that object.</param>
        /// <returns>Show associated with Id input.</returns>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ShowService showService = CreateShowService();
            var show = showService.GetShowById(id);
            return Ok(show);
        }
        /// <summary>
        /// Allows user to update the ShowTime/Feature properties of an existing show object.
        /// </summary>
        /// <param name="show">Takes in new Showtime/Feature information for update.</param>
        /// <returns>Success Message.</returns>
        [HttpPut]
        public IHttpActionResult Put(ShowEdit show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.UpdateShow(show))
                return InternalServerError();

            return Ok("Show Successfully Updated");
        }
        /// <summary>
        /// Allows user to add individual tickets to a show object.
        /// </summary>
        /// <param name="model">Takes in all ticket properties and adds them as an object to the database.</param>
        /// <returns>Success Message.</returns>
        [HttpPost]
        [Route("api/Show/Ticket")]
        public IHttpActionResult AddTicketsToShow(TicketCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTickService();

            if (!service.CreateTicket(model))
                return InternalServerError();
            return Ok("Ticket Successfully Added To Show!");
        }
        /// <summary>
        /// Returns a list of all tickets by Show Id
        /// </summary>
        /// <param name="showId">Takes a Show Id in as a URI parameter, and returns all ticket objects attached to that show.</param>
        /// <returns>All tickets associated with Show Id input..</returns>
        [HttpGet]
        [Route("api/Show/Ticket")]
        public IHttpActionResult GetTicketsByShow(int showId)
        {

            TicketService tickService = new TicketService();
            var ticket = tickService.GetTicketByShow(showId);
            return Ok(ticket);
        }
        /// <summary>
        /// Deletes a Show Object from the Show Database
        /// </summary>
        /// <param name="id">Takes in a ShowId as a URI parameter, and deletes the object from the database.</param>
        /// <returns>Success Message.</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            {
                var service = CreateShowService();

                if (!service.DeleteShow(id))
                    return InternalServerError();

                return Ok("Show Successfully Deleted");
            }
        }
        /// <summary>
        /// Create a New Work Order to be filled.
        /// </summary>
        /// <param name="workOrder">Takes in a Work Order by the Parameters in the Body, and Adds the New Object to the Database</param>
        /// <returns>Success Message.</returns>
        [HttpPost]
        [Route("api/Show/WorkOrder")]
        public IHttpActionResult PostWorkOrder(WorkOrderCreate workOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new WorkOrderService();

            if (!service.CreateWorkOrder(workOrder))
                return InternalServerError();

            return Ok("Work Order Created");
        }
        /// <summary>
        /// Returns a List of ALL Work Orders
        /// </summary>
        /// <returns>Full List of All Current Work Orders in System.</returns>
        [HttpGet]
        [Route("api/Show/WorkOrder")]
        public IHttpActionResult GetAllWorkOrders()
        {
            var service = new WorkOrderService();
            var workOrders = service.GetWorkOrders();
            return Ok(workOrders);
        }
        /// <summary>
        /// Returns a single Work Order.
        /// </summary>
        /// <param name="id">Takes in a WorkOrderId as a URI Parameter, and Returns That Object.</param>
        /// <returns>Returns Work Order Associated with Id input.</returns>
        [HttpGet]
        [Route("api/WorkOrder/{id}")]
        public IHttpActionResult GetSingleWorkOrder(int id)
        {
            var service = new WorkOrderService();
            var workOrders = service.GetWorkOrder(id);
            return Ok(workOrders);
        }
        /// <summary>
        /// Allows a User to Alter the Details of an Existing Work Order Object.
        /// </summary>
        /// <param name="workOrderEdit">Takes in the parameters defined in the body, and updates that Work Order Object in the Database.</param>
        /// <returns>Success Message.</returns>
        [HttpPut]
        [Route("api/Show/WorkOrder")]
        public IHttpActionResult UpdateWorkOrder(WorkOrderEdit workOrderEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new WorkOrderService().UpdateWorkOrder(workOrderEdit);

            if (!service)
                return InternalServerError();

            return Ok("Work Order Updated");
        }
        /// <summary>
        /// Deletes a Work Order Object.
        /// </summary>
        /// <param name="id">Takes in a WorkOrderId as a URI Parameter, and Deletes that Object from the Database.</param>
        /// <returns>Success Message.</returns>
        [HttpDelete]
        [Route("api/Show/WorkOrder")]
        public IHttpActionResult DeleteWorkOrder(int id)
        {
            var service = new WorkOrderService();
            if (!service.DeleteWorkOrder(id))
                return InternalServerError();

            return Ok("Work Order Deleted");
        }
    }
}
