using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventWarez.Data.Ticket;

namespace EventWarez.Models
{
    public class TicketCreate
    {
        public int? AttId { get; set; }
        //public int? ShowId { get; set; }
        public int Price { get; set; }
        public TicketType TypeOfTicket { get; set; }

        public int TCount { get; set; }
    }
}
