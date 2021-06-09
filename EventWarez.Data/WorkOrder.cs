using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Data
{
    public class WorkOrder
    {
        [Key]
        public int WorkOrderId { get; set; }

        [Required]
        [ForeignKey(nameof(Staff))]
        public int? StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        [Required]
        [ForeignKey(nameof(Show))]
        public int? ShowId { get; set; }
        public virtual Show Show { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
