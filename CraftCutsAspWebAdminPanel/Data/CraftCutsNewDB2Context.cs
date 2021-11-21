using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CraftCutsAspWebAdminPanel.Models;

#nullable disable

namespace CraftCutsAspWebAdminPanel.Data
{
    public partial class CraftCutsNewDB2Context : DbContext
    {
        public CraftCutsNewDB2Context()
        {
        }

        public CraftCutsNewDB2Context(DbContextOptions<CraftCutsNewDB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Barber> Barbers { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingList> BookingLists { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DemoBeard> DemoBeards { get; set; }
        public virtual DbSet<HairCut> HairCuts { get; set; }
        public virtual DbSet<Promocode> Promocodes { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:craftcuts1.database.windows.net,1433;Initial Catalog=CraftCutsNewDB2;Persist Security Info=False;User ID=admin123;Password=qwertY1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasOne(d => d.Barber)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BarberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Barber");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Customer");

                entity.HasOne(d => d.Promocode)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PromocodeId)
                    .HasConstraintName("FK_Booking_Promocode");
            });

            modelBuilder.Entity<BookingList>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.ServiceId });

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingLists)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingList_Booking");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.BookingLists)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingList_Service");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Customer");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Name).IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
