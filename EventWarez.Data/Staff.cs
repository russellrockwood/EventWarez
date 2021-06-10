using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Data
{
    public enum Department { BoxOffice, Catering, Security, Marketing}
    public enum AccessLevel { Low, Medium, High}
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Department Department { get; set; }

        [Required]
        public AccessLevel AccessLevel { get; set; }

        public virtual List<WorkOrder> WorkOrders { get; set; }
    }
}
