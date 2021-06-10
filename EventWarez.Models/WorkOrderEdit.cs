using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Models
{
    public class WorkOrderEdit
    {
        public int WorkOrderId { get; set; }
        public int StaffId { get; set; }
        public int ShowId { get; set; }
    }
}
