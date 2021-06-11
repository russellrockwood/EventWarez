using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Models.Show
{
    public class ShowCreate
    {
        [Required]
        public string Feature { get; set; }
        [Required]
        public DateTime ShowTime { get; set; }
    }
}
