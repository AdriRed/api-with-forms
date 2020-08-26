using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIWithForms.Entities;

namespace APIWithForms.API.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlite($"Data Source=C:\\colors.db");
        //    throw new Exception("Not allowed entry. Custom exception.");
        //}

        public DbSet<UserColor> UserColors { get; set; }
    }
}
