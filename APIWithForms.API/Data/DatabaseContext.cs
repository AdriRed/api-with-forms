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

        public DbSet<UserColor> UserColors { get; set; }
    }
}
