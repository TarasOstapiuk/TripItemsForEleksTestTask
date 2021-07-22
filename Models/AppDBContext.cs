using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripItemsForEleks.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base (options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemsToTrip>()
                .HasOne(t => t.Trip)
                .WithMany(itt => itt.ItemsToTrip)
                .HasForeignKey(ti => ti.TripId);
            modelBuilder.Entity<ItemsToTrip>()
                .HasOne(t => t.Item)
                .WithMany(itt => itt.ItemsToTrip)
                .HasForeignKey(ti => ti.ItemId);
            /*modelBuilder.Entity<Trip>()
                    .Property(p => p.Id)
                    .ValueGeneratedOnAdd();*/
            modelBuilder.Entity<Trip>().HasData(
                    new Trip
                    {
                        Id = 3, TripName = "Odessa", ItemsToTrip = null
                    },
                    new Trip
                    {
                        Id = 4,
                        TripName = "Sambir",
                        ItemsToTrip = null
                    }

                );
            modelBuilder.Entity<Item>().HasData(
                    new Item
                    {
                        Id = 1,
                        ItemName = "Pen",
                        ItemsToTrip = null
                    },
                    new Item
                    {
                        Id = 2,
                        ItemName = "Condoms",
                        ItemsToTrip = null
                    }
            );
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<ItemsToTrip> ItemsToTrips { get; set; }

    }
}
