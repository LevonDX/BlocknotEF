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

            // add lazy loading
            optionsBuilder.UseLazyLoadingProxies();

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

            var countries = new[]
            {
                new Country { Id = 1, Name = "Armenia", Code = "AM" },
                new Country { Id = 2, Name = "United States", Code = "US" },
                new Country { Id = 3, Name = "United Kingdom", Code = "UK" },
                new Country { Id = 4, Name = "France", Code = "FR" },
                new Country { Id = 5, Name = "Germany", Code = "DE" },
                new Country { Id = 6, Name = "Japan", Code = "JP" },
                new Country { Id = 7, Name = "Australia", Code = "AU" },
                new Country { Id = 8, Name = "Russia", Code = "RU" },
                new Country { Id = 9, Name = "China", Code = "CN" },
                new Country { Id = 10, Name = "Brazil", Code = "BR" }
            };
            modelBuilder.Entity<Country>().HasData(countries);

            // Seed cities with a clear relationship to countries
            var cities = new[]
            {
                new City { Id = 1, Name = "Yerevan", CountryId = 1 }, // Referencing Armenia
                new City { Id = 2, Name = "New York", CountryId = 2 }, // Referencing United States
                new City { Id = 3, Name = "London", CountryId = 3 }, // Referencing United Kingdom
                new City { Id = 4, Name = "Paris", CountryId = 4 }, // Referencing France
                new City { Id = 5, Name = "Berlin", CountryId = 5 }, // Referencing Germany
                new City { Id = 6, Name = "Tokyo", CountryId = 6 }, // Referencing Japan
                new City { Id = 7, Name = "Sydney", CountryId = 7 }, // Referencing Australia
                new City { Id = 8, Name = "Moscow", CountryId = 8 }, // Referencing Russia
                new City { Id = 9, Name = "Beijing", CountryId = 9 }, // Referencing China
                new City { Id = 10, Name = "Rio de Janeiro", CountryId = 10 } // Referencing Brazil
            };
            modelBuilder.Entity<City>().HasData(cities);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Record> Records { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
