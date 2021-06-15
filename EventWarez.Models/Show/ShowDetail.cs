﻿using EventWarez.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Models.Show
{
    public class ShowDetail
    {
        public int ShowId { get; set; }

        public string Feature { get; set; }

        public DateTime ShowTime { get; set; }

        public List<TicketListItem> Tickets { get; set; }

        public List<WorkOrderDetail> WorkOrders { get; set; }

    }
}
