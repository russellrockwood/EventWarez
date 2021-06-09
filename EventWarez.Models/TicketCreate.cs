using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventWarez.Data.Ticket;

namespace EventWarez.Models.Ticket
    //This Belongs in the Show Services
{
    public class TicketCreate
    {
        public int Price { get; set; }
        public TicketType TypeOfTicket { get; set; }
        public int? ShowId { get; set; }
    }
}
