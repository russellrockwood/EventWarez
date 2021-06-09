using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Models.Ticket
{
    //This belongs in the Attendee Services.
    public class TicketDetail
    {
        public int TicketId { get; set; }
        public string Feature { get; set; }
        public int? AttId { get; set; }
    }
}
