using EventWarez.Data;
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
        public int? StaffId { get; set; }

        public int ShowId { get; set; }

        public Department Department { get; set; }

    }
}
