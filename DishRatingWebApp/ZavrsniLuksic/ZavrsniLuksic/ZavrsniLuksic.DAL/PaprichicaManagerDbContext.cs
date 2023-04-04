using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZavrsniLuksic.Model;

namespace ZavrsniLuksic.DAL
{
    public class PaprichicaManagerDbContext : DbContext
    {
        public PaprichicaManagerDbContext(DbContextOptions<PaprichicaManagerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Cuisine> Cuisines { get; set; }

        public DbSet<Spiciness> Spicinesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cuisine>().HasData(new Cuisine { ID = 1, Name = "Talijanska" });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine { ID = 2, Name = "Meksička" });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine { ID = 3, Name = "Francuska" });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine { ID = 4, Name = "Japanska" });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine { ID = 5, Name = "Kineska" });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine { ID = 6, Name = "Španjolska" });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine { ID = 7, Name = "Etiopska" });

            modelBuilder.Entity<Spiciness>().HasData(new Spiciness { ID = 1, Level = "Nije ni posoljeno" });
            modelBuilder.Entity<Spiciness>().HasData(new Spiciness { ID = 2, Level = "Prstohvat cimeta mi je doseg" });
            modelBuilder.Entity<Spiciness>().HasData(new Spiciness { ID = 3, Level = "Pikantno" });
            modelBuilder.Entity<Spiciness>().HasData(new Spiciness { ID = 4, Level = "Neki to vole vruće" });
            modelBuilder.Entity<Spiciness>().HasData(new Spiciness { ID = 5, Level = "Eh, da je Dante samo znao za tebe..." });

            modelBuilder.Entity<Restaurant>().HasData(new Restaurant { ID = 1, Name = "Boban", CuisineID = 1, Address = "Gajeva 9, Zagreb", PhoneNumber = "4811549", Url = "http://www.boban.hr/home" });
            modelBuilder.Entity<Restaurant>().HasData(new Restaurant { ID = 2, Name = "Mex Cantina", CuisineID = 2, Address = "Savska cesta 154, Zagreb", PhoneNumber = "6192156", Url = "https://mexcantina.eatbu.hr/?lang=hr" });


            modelBuilder.Entity<Dish>().HasData(new Dish { ID = 1, Name = "Lasagne Bolognese", Description = "Lazanje sa umakom od mljevenog mesa dinstanog na luku, češnjaku, rajčicama te maslinovom ulju sa začinima.", Price = "78", RestaurantID = 1, SpicinessID = 1 });
            modelBuilder.Entity<Dish>().HasData(new Dish { ID = 2, Name = "Rustica", Description = "Šnite bifteka s pečenim krumpirom, rukolom, crvenim radičem i cherry rajčicama.", Price = "158", RestaurantID = 1, SpicinessID = 2 });
            modelBuilder.Entity<Dish>().HasData(new Dish { ID = 3, Name = "Nopalitos con frijoles", Description = "Zapečeni kaktus s grahom i Jalapeno paprikom.", Price = "55", RestaurantID = 2, SpicinessID = 4 });
            modelBuilder.Entity<Dish>().HasData(new Dish { ID = 4, Name = "Pollo con mole poblano", Description = "Piletina u umaku od kakaa, gljive i 20 vrsta začina.", Price = "100", RestaurantID = 2, SpicinessID = 3 });
            modelBuilder.Entity<Dish>().HasData(new Dish { ID = 5, Name = "Alitas de pollo en chili", Description = "Pileća krilca u marinadi od chilija.", Price = "80", RestaurantID = 2, SpicinessID = 5 });
        }

    }
}