using EventWarez.Models.Staff;
using EventWarez.Services;
using System.Web.Http;

namespace EventWarez.WebAPI.Controllers
{
    public class StaffController : ApiController
    {
        [Authorize]
        public IHttpActionResult Post(StaffCreate staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staffService = new StaffService();

            if (!staffService.CreateStaff(staff))
            {
                return InternalServerError();
            }

            return Ok("Staffmember Created");
        }

        public IHttpActionResult Get()
        {
            var staffService = new StaffService();
            var staffDetails = staffService.GetStaffDetails();
            return Ok(staffDetails);
        }

        public IHttpActionResult Get(int id)
        {
            var staffMember = new StaffService().GetStaffById(id);
            return Ok(staffMember);
        }

        public IHttpActionResult Put(StaffEdit staff)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool service = new StaffService().UpdateStaff(staff);
            if (!service)
                return InternalServerError();

            return Ok("Staff Updated");
        }

        public IHttpActionResult Delete(int id)
        {
            bool service = new StaffService().DeleteStaff(id);

            if (!service)
                return InternalServerError();

            return Ok("Staff Deleted");
        }

    }
}
