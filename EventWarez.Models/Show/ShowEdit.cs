using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Models.Show
{
    public class ShowEdit
    {
        [Required] 
        public int ShowId { get; set; }

        public string Feature { get; set; }

        public DateTime ShowTime { get; set; }
    }
}
