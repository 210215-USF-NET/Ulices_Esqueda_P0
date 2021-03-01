using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SDL.Entities
{
    public partial class p0dbContext : DbContext
    {
        public p0dbContext()
        {
        }

        public p0dbContext(DbContextOptions<p0dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LocationVisited> LocationVisiteds { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreInventory> StoreInventories { get; set; }
        public virtual DbSet<TrackOrder> TrackOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerFirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerLastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocationVisited>(entity =>
            {
                entity.ToTable("LocationVisited");

                entity.Property(e => e.LocationVisitedId).HasColumnName("LocationVisitedID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.LocationVisiteds)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__LocationV__Custo__1CBC4616");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.LocationVisiteds)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__LocationV__Store__1DB06A4F");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.ManagerFirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerLastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderDate).HasColumnType("date");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderItem__Produ__339FAB6E");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.StoreLocation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreManagerId).HasColumnName("StoreManagerID");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.StoreManager)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.StoreManagerId)
                    .HasConstraintName("FK__Store__StoreMana__19DFD96B");
            });

            modelBuilder.Entity<StoreInventory>(entity =>
            {
                entity.ToTable("StoreInventory");

                entity.Property(e => e.StoreInventoryId).HasColumnName("StoreInventoryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__StoreInve__Produ__2180FB33");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__StoreInve__Store__208CD6FA");
            });

            modelBuilder.Entity<TrackOrder>(entity =>
            {
                entity.ToTable("TrackOrder");

                entity.Property(e => e.TrackOrderId).HasColumnName("TrackOrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TrackOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__TrackOrde__Custo__367C1819");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TrackOrders)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__TrackOrde__Order__37703C52");

                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.TrackOrders)
                    .HasForeignKey(d => d.OrderItemId)
                    .HasConstraintName("FK__TrackOrde__Order__3864608B");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.TrackOrders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__TrackOrde__Store__395884C4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
