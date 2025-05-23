using System;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Context
{
    public class CarBookDbContext : DbContext
    {
        public CarBookDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeatures> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<FooterAdress> FooterAdresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RentACar> RentACars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasOne(x=>x.PickUpLocation).WithMany(y=>y.PickUpReservation).HasForeignKey(x=>x.PickUpLocationId);
            modelBuilder.Entity<Reservation>().HasOne(x=>x.DrofOffLocation).WithMany(y=>y.DropOffReservation).HasForeignKey(x=>x.DropOffLocationId);
            
            // Add unique constraint to prevent duplicate car-feature combinations
            modelBuilder.Entity<CarFeatures>()
                .HasIndex(cf => new { cf.CarId, cf.FeaturesId })
                .IsUnique();
        }
    }
    
        
}