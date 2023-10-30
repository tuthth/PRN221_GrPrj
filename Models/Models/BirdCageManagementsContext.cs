using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Models.Models;

public partial class BirdCageManagementsContext : DbContext
{
    public BirdCageManagementsContext()
    {
    }

    public BirdCageManagementsContext(DbContextOptions<BirdCageManagementsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductionStep> ProductionSteps { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<WorkOn> WorkOns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());
    private static string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        var strConn = config["ConnectionStrings:BirdCageManagements"];
        return strConn;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B86B31D0C1");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PK__Expenses__1445CFF31BB4BEE0");

            entity.Property(e => e.ExpenseId)
                .ValueGeneratedNever()
                .HasColumnName("ExpenseID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DateIncurred).HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Inventor__F5FDE6D3320E3317");

            entity.Property(e => e.InventoryId)
                .ValueGeneratedNever()
                .HasColumnName("InventoryID");
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

            entity.HasOne(d => d.Material).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK__Inventory__Mater__45F365D3");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__Material__C50613172A5A001A");

            entity.Property(e => e.MaterialId)
                .ValueGeneratedNever()
                .HasColumnName("MaterialID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAFEBE506C5");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DatePlaced).HasColumnType("date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Order__CustomerI__398D8EEE");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06A1860628A1");

            entity.Property(e => e.OrderItemId)
                .ValueGeneratedNever()
                .HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__3E52440B");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__Produ__3F466844");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6EDAE01B781");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ProductionStep>(entity =>
        {
            entity.HasKey(e => e.StepId).HasName("PK__Producti__2434333766EFC385");

            entity.Property(e => e.StepId)
                .ValueGeneratedNever()
                .HasColumnName("StepID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF79549C9DC");

            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("StaffID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WorkOn>(entity =>
        {
            entity.HasKey(e => e.WorkOnId).HasName("PK__WorkOn__B9F6C9D9A73A0A53");

            entity.Property(e => e.WorkOnId)
                .ValueGeneratedNever()
                .HasColumnName("WorkOnID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.StepId).HasColumnName("StepID");

            entity.HasOne(d => d.Staff).WithMany(p => p.WorkOns)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__WorkOn__StaffID__4BAC3F29");

            entity.HasOne(d => d.Step).WithMany(p => p.WorkOns)
                .HasForeignKey(d => d.StepId)
                .HasConstraintName("FK__WorkOn__StepID__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
