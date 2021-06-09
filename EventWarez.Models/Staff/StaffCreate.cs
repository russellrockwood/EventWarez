using EventWarez.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Models.Staff
{
    public class StaffCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(50, ErrorMessage = "50 characters max")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(50, ErrorMessage = "50 characters max")]
        public string LastName { get; set; }

        [Required]
        public Department Department { get; set; }

        [Required]
        public AccessLevel AccessLevel { get; set; }
     
    }
}
