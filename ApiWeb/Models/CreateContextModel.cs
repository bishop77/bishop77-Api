using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Models
{

    public class CreateContextModel : DbContext
    {
        public DbSet<Animals> Animals { get; set; }
        public DbSet<Leather> Leathers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Region> Regions{ get; set; }
        public CreateContextModel(DbContextOptions<CreateContextModel> options):base(options){
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animals>().ToTable("Animals");
            modelBuilder.Entity<Leather>().ToTable("Leathers");
            modelBuilder.Entity<Location>().ToTable("Locations");
            modelBuilder.Entity<Region>().ToTable("Regions");
        }
    }

}
