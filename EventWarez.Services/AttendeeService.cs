using EventWarez.Data;
using EventWarez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Services
{
    public class AttendeeService
    {
        //Post
        public bool AddAttendee(AttendeeCreate model)
        {
            var entity =
                new Attendee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attendees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Get
        public IEnumerable<AttendeeListItem> GetAttendees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Attendees.Select(e => new AttendeeListItem { AttId = e.AttId, FirstName = e.FirstName, LastName = e.LastName });
                return query.ToArray();
            }
        }
    }
}
