using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalScheduleServiceAPI.Models
{
    public class LocalBooking
    {
        public int Id { get; set; }
        public int StartDateTime { get; set; } 
        public int EndDateTime { get; set; } 

        public int LocalId { get; set; } // FK
        public Local Locals { get; set; } // FK

        public int EventId { get; set; } // FK
    }
}
