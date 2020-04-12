using Data.DominiCode.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DominiCode.DBContext
{
    public class DominiContext : DbContext
    {
        public DbSet<ClientCategory> ClientCategories { get; set; }
        public DbSet<Clients> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLOCALDB;Database=DominiBD;Trusted_Connection=True;");
        }
    }
}
