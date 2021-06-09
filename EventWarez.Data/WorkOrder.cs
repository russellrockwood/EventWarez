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
        public int Id { get; set; }

        [ForeignKey(nameof(Staff))]
        public int? StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        [ForeignKey(nameof(Show))]
        public int? ShowId { get; set; }
        public virtual Show Show { get; set; }
    }

}
