using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalScheduleServiceAPI.Models
{
    public class LocalContext : DbContext
    {
        public DbSet<LocalBooking> LocalBooking { get; set; }
        public DbSet<Local> Locals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=locals.db");
        }
    }
}
