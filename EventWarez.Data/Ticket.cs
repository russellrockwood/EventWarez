using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Data
{
    public class Ticket
    {
        
        public int TicketId { get; set; }
        public int? ShowId { get; set; }
        public virtual Show Show { get; set; }
        public int? AttId { get; set; }
        public virtual Attendee Attendee { get; set; }

        [Required]
        public int Price { get; set; }

        public enum TicketType { General, VIP }
        [Required]
        public TicketType TypeOfTicket { get; set; }
    }
}
