using EventWarez.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Models.Staff
{
    public class StaffDetail
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public virtual List<WorkOrderDetail> WorkOrders { get; set; }
    }
}
