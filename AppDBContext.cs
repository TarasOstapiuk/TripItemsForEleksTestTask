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
           /* Database.EnsureDeleted();
            Database.EnsureCreated();*/
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
            modelBuilder.Entity<Trip>()
                    .Property(p => p.Id)
                    .ValueGeneratedOnAdd();
            
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<ItemsToTrip> ItemsToTrips { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //}

    }


}
