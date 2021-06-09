using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Models
{
    public class WorkOrderCreate
    {
        [Required]
        public int? StaffId { get; set; }

        [Required]
        public int? ShowId { get; set; }
    }
}
