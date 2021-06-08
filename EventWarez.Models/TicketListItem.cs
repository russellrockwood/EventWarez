using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventWarez.Data;
using static EventWarez.Data.Ticket;

namespace EventWarez.Models
{
    public class TicketListItem
    {
        public int TicketId { get; set; }
        public int Price { get; set; }
        public TicketType TypeTicket { get; set; }
        public int TCount { get; set; }
    }
}
