using EventWarez.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Models.Attendee
{
    public class AttendeeDetail
    {
        public int AttId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TicketListItem> Tickets { get; set; }
    }
}
