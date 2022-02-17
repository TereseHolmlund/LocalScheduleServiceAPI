using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalScheduleServiceAPI.Models
{
    public class LocalContext : DbContext
    {
        public DbSet<LocalBooking> LocalBookings { get; set; }

        public LocalContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<LocalScheduleServiceAPI.Models.Local> Local { get; set; }
      

    }
}
