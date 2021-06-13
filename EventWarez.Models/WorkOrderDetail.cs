using EventWarez.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Models
{
    public class WorkOrderDetail
    {
        public int WorkOrderId { get; set; }
        public int? StaffId { get; set; }
        public int ShowId { get; set; }

        public bool IsFilled { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
