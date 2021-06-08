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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; }
        public AccessLevel AccessLevel { get; set; }

        //public virtual List<StaffOnHand> {get; set;}
    }
}
