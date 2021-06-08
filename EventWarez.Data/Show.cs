using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Data
{
    public class Show
    {
        [Key]
        public int ShowId { get; set; }

        ////Removed GUID requirement
        //[Required]
        //public Guid OwnerId { get; set; }

        [Required]
        public string Feature { get; set; }

        [Required]
        public DateTime ShowTime { get; set; }

        //public virtual List<StaffOnHand> StaffOnHands { get; set; }

        public virtual List<Ticket> Tickets { get; set; }
    }
}
