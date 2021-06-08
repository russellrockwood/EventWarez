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
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Attendee))]
        public int AttId { get; set; }
        public virtual Attendee Attendee { get; set; }
        //[ForeignKey(nameof(Show))]
        //public int ShowId { get; set; }
        //public virtual Show Show { get; set; }
        public int Price { get; set; }
        public enum TicketType { General, VIP }
        public TicketType TypeOfTicket { get; set; }
    }
}
