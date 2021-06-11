using EventWarez.Data;
using EventWarez.Models;
using EventWarez.Models.Attendee;
using EventWarez.Models.Ticket;
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

        public AttendeeDetail GetTicketByAttendee(int attId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx.Attendees.Single(e => e.AttId == attId);

                return new AttendeeDetail
                {
                    AttId = attId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Tickets = entity.Tickets
                    .Select(e => new TicketListItem()
                    {
                        TicketId = e.TicketId,
                        Price=e.Price,
                        TypeTicket=e.TypeOfTicket,
                        Feature=e.Show.Feature,
                        ShowTime=e.Show.ShowTime
                    }).ToList()
            };
        }
    }
}
}
