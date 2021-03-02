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
                    .HasConstraintName("FK__LocationV__Custo__7D0E9093");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.LocationVisiteds)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__LocationV__Store__7E02B4CC");
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

                entity.Property(e => e.OrderDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderItem__Produ__7755B73D");
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
                    .HasConstraintName("FK__Store__StoreMana__7A3223E8");
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
                    .HasConstraintName("FK__StoreInve__Produ__01D345B0");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__StoreInve__Store__00DF2177");
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
                    .HasConstraintName("FK__TrackOrde__Custo__04AFB25B");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TrackOrders)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__TrackOrde__Order__05A3D694");

                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.TrackOrders)
                    .HasForeignKey(d => d.OrderItemId)
                    .HasConstraintName("FK__TrackOrde__Order__0697FACD");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.TrackOrders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__TrackOrde__Store__078C1F06");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
