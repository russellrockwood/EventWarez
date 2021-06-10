﻿using EventWarez.Data;
using EventWarez.Models.Show;
using EventWarez.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Services
{
    //This class might not (read: probably does not) need to exist.
    public class TicketService
    {
        //Post
        public bool CreateTicket(TicketCreate model)
        {
            var entity =
                new Ticket()
                {
                    ShowId = model.ShowId,
                    Price = model.Price,
                    TypeOfTicket = model.TypeOfTicket
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tickets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TicketListItem> GetTickets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Tickets.Select(e => new TicketListItem { TicketId = e.TicketId, Price = e.Price, TypeTicket = e.TypeOfTicket });
                return query.ToArray();
            }
        }

        public bool AddAttendeeToTicket(TicketEdit ticket)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Tickets.Single(e => e.TicketId == ticket.TicketId);
                entity.TicketId = ticket.TicketId;
                entity.Show.Feature = ticket.Feature;
                entity.AttId = ticket.AttId;

                return ctx.SaveChanges() == 1;
            }
            
        }

        public ShowDetail GetTicketByShow(int showId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shows
                    .Single(e => e.ShowId == showId);
                return
                    new ShowDetail
                    {
                        ShowId = showId,
                        Feature = entity.Feature,
                        ShowTime = entity.ShowTime,
                        Tickets = entity.Tickets
                        .Select(e => new TicketListItem()
                        {
                            TicketId = e.TicketId,
                            Price = e.Price,
                            TypeTicket = e.TypeOfTicket,
                            Feature = e.Show.Feature,
                            ShowTime = e.Show.ShowTime
                        }).ToList()
                    };

            }
        }
    }
}
