using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Data
{
    public enum Department { BoxOffice, Bar, Security, Floor }
    public class WorkOrder
    {

        [Key]
        public int WorkOrderId { get; set; }

        public int? StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public bool IsFilled 
        {
            get 
            {
                return (StaffId == null) ? false : true;
            } 
        }

        [Required]
        public int ShowId { get; set; }
        public virtual Show Show { get; set; }

        [Required]
        public Department Department { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
