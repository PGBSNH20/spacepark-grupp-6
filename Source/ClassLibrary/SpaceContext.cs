using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class SpaceContext : DbContext
    {
        public SpaceContext()
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer("server=.;database=SpacePark;trusted_connection=true;");
        }
        public virtual DbSet<Parking> Parkings { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
