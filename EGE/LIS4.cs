using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EGE
{
    public class LIS4 : DbContext
    {
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public LIS4()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=sigma4.db");
        }
    }
}
