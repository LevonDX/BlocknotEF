global using BlocknotEF.Data.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotEF.Data.Context
{
    public class BlocknotDbContext : DbContext
    {
        private const string ConnectionString = "Data Source=lectures-db-dev.database.windows.net;Initial Catalog=BlocknotDB;Persist Security Info=True;User ID=ad;Password=Ararat73;Encrypt=True;Trust Server Certificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Country>()
                .HasIndex(c => c.Name)
                .IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Record> Records { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
