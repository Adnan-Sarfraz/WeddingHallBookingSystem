using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeddingHall.Domain;
using WeddingHall.Domain.ViewModels;
using WeddingHall.Infrastructure;

namespace WeddingHall.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {   
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define your tables here
        //public DbSet<User> Users { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<HallMaster> HallMasters { get; set; }
        public DbSet<SubHallDetail> SubHallDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Users> UserManagers { get; set; }
        public DbSet<SubHallUserAssociate> SubHallUserAssociates { get; set; }
        public DbSet<City>Cities {get; set;}
        public DbSet<District>Districts { get; set; }

        //------------------------------------------------------------------------------------------

        public DbSet<NewRequestView> NewRequests { get; set; }
        public DbSet<TodayBookingView> TodayBookings { get; set; }
        public DbSet<Next15DaysBookingView> Next15DaysBookings { get; set; }


        //------------------------------------------------------------------------------------------



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //------------------------------------------------------------------------------------------

            // Map Views as Keyless Entities
            modelBuilder.Entity<NewRequestView>().HasNoKey().ToView("vw_NewRequests");
            modelBuilder.Entity<TodayBookingView>().HasNoKey().ToView("vw_TodayBookings");
            modelBuilder.Entity<Next15DaysBookingView>().HasNoKey().ToView("vw_Next15DaysBookings");

            //------------------------------------------------------------------------------------------


            // ====================== HALL ======================
            modelBuilder.Entity<Hall>(entity =>
            {
                entity.Property(h => h.HallName).HasMaxLength(100);
                entity.Property(h => h.ManagerName).HasMaxLength(100);
                entity.Property(h => h.Phone).HasMaxLength(20);
                entity.Property(h => h.Email).HasMaxLength(100);
                entity.Property(h => h.City).HasMaxLength(50);
                entity.Property(h => h.Address).HasMaxLength(200);

                // Decimal precision
                entity.Property(h => h.PriceWithDinner).HasPrecision(18, 2).HasDefaultValue(0m);
                entity.Property(h => h.PriceWithoutDinner).HasPrecision(18, 2).HasDefaultValue(0m);

                // Default values for int
                entity.Property(h => h.Capacity).HasDefaultValue(0);
            });
           


            // ====================== BOOKING ======================
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(b => b.TimeSlot).HasMaxLength(20);
                entity.Property(b => b.Notes).HasMaxLength(300);

                entity.Property(b => b.Guests).HasDefaultValue(0);
                entity.Property(b => b.DinnerRequired).HasDefaultValue(false);

                // Relationships
                entity.HasOne<Hall>()
                      .WithMany()
                      .HasForeignKey(b => b.HallId)
                      .OnDelete(DeleteBehavior.Restrict);

        
            });


            // ====================== FAVORITE ======================
            modelBuilder.Entity<Favorite>(entity =>
            {

                entity.HasKey(f => f.HallId);

               

                entity.HasOne<Hall>()
                      .WithMany()
                      .HasForeignKey(f => f.HallId)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // ====================== AVAILABILITY ======================
            modelBuilder.Entity<Availability>(entity =>
            {
                entity.Property(a => a.Slot).HasMaxLength(20);
                entity.Property(a => a.IsAvailable).HasDefaultValue(true);

                entity.HasOne<Hall>()
                      .WithMany()
                      .HasForeignKey(a => a.HallId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ====================== HALL MASTER ======================
            modelBuilder.Entity<HallMaster>(entity =>
            {
                entity.HasKey(h => h.GUID);

                entity.Property(h => h.HallName).HasMaxLength(150);
                entity.Property(h => h.HallAddress).HasMaxLength(250);

                // Foreign key linking to City
                entity.HasOne(h => h.City)
                      .WithMany()
                      .HasForeignKey(h => h.CityId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(h => h.District)
                      .WithMany()
                      .HasForeignKey(h => h.DistrictId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ====================== SUB HALL DETAIL ======================
            modelBuilder.Entity<SubHallDetail>(entity =>
            {
                entity.HasKey(s => s.GUID); // Primary Key

                entity.Property(s => s.SubHall_Name).HasMaxLength(150);
                entity.Property(s => s.Capacity).HasDefaultValue(0);

                entity.Property(s => s.Inserted_By).HasMaxLength(100);
                entity.Property(s => s.Updated_By).HasMaxLength(100);

                entity.Property(s => s.Inserted_Date)
                      .HasDefaultValueSql("GETDATE()");

                //  Foreign Key Relationship with HallMaster
                entity.HasOne(s => s.HallMaster)
                      .WithMany()
                      .HasForeignKey(s => s.Hall_id)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ====================== ROLE ======================
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.GUID);

                entity.Property(r => r.RoleName).HasMaxLength(100);
                entity.Property(r => r.RoleCode).HasMaxLength(50);

                entity.Property(r => r.Inserted_By).HasMaxLength(100);
                entity.Property(r => r.Updated_By).HasMaxLength(100);

                entity.Property(r => r.Inserted_Date)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(r => r.RoleCode).IsUnique(); // No duplicate role codes
            });

            // ====================== USERS ======================
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(u => u.GUID);

                entity.Property(u => u.UserName).HasMaxLength(100);
                entity.Property(u => u.PhoneNo).HasMaxLength(20);
                entity.Property(u => u.Email).HasMaxLength(150);
                entity.Property(u => u.Password).HasMaxLength(200);

                entity.Property(u => u.Inserted_By).HasMaxLength(100);
                entity.Property(u => u.Updated_By).HasMaxLength(100);

                entity.Property(u => u.Inserted_Date)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(u => u.Email).IsUnique(); // No duplicate emails

                // FK → Role
                entity.HasOne(u => u.Role)
                      .WithMany()
                      .HasForeignKey(u => u.RoleId)
                      .OnDelete(DeleteBehavior.Restrict);

                // FK → HallMaster
                entity.HasOne(u => u.HallMaster)
                      .WithMany()
                      .HasForeignKey(u => u.HallId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ====================== SUB HALL USER ASSOCIATE ======================
            modelBuilder.Entity<SubHallUserAssociate>(entity =>
            {
                entity.HasKey(s => s.GUID);

                entity.Property(s => s.Inserted_By).HasMaxLength(100); 
                entity.Property(s => s.Updated_By).HasMaxLength(100);

                entity.Property(s => s.Inserted_Date)
                    .HasDefaultValueSql("GETDATE()");

                // FK → UserManager
                entity.HasOne(s => s.UserManager)
                    .WithMany() 
                    .HasForeignKey(s => s.UserId) 
                    .OnDelete(DeleteBehavior.Cascade); 

                // FK → SubHallDetail
                entity.HasOne(s => s.SubHallDetail)
                    .WithMany()
                    .HasForeignKey(s => s.SubHall_Id) 
                    .OnDelete(DeleteBehavior.Cascade); 

                // Prevent duplicate assignment of same user to same sub hall
                    entity.HasIndex(s => new { s.UserId, s.SubHall_Id }).IsUnique();
            });

            // ====================== CITY ======================
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(c => c.Guid);  // Only ONE PK

                entity.Property(c => c.CityName).HasMaxLength(100); 

                entity.HasIndex(c => c.CityCode).IsUnique(); // CityCode must be unique if needed

                entity.HasOne(c => c.District) 
                    .WithMany() 
                    .HasForeignKey(c => c.Districtode) 
                    .OnDelete(DeleteBehavior.Restrict);
            });

                //modelBuilder.Entity<City>(entity =>
                //{
                //    entity.HasKey(c => c.Guid);
                //    entity.Property(c => c.CityName).HasMaxLength(100);
                //    entity.HasKey(c => c.CityCode);


                //    // FK → DistrictCode
                //   entity.HasOne(c => c.District)
                //          .WithMany()
                //          .HasForeignKey(u => u.Districtode)
                //          .OnDelete(DeleteBehavior.Restrict);

                //});
                // ====================== DISTRICT ======================
            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(d => d.Guid); // Only ONE PK
                entity.Property(d => d.DistrictName).HasMaxLength(100);

                entity.HasIndex(d => d.DisctrictCode).IsUnique(); // Unique but NOT PK
            });

            //modelBuilder.Entity<District>(entity =>
            //{
            //    entity.HasKey( D=> D.Guid);
            //    entity.Property(D => D.DistrictName).HasMaxLength(100);
            //    entity.HasKey(D => D.DisctrictCode);

            //});
        }
    }
}
