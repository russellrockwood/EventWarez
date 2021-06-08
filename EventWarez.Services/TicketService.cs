using EventWarez.Data;
using EventWarez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Services
{
    public class TicketService
    {
        public bool CreateTicket(TicketCreate model)
        {
            var entity =
                new Ticket()
                {
                    Price = model.Price,
                    TypeOfTicket = model.TypeOfTicket
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tickets.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
