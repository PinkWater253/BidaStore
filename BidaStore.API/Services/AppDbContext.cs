using System;
using System.Collections.Generic;
using BidaStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BidaStore.API.Services;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-UM7849T\\SQLEXPRESS;Initial Catalog=BidaTrader;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cart__3213E83FBEAC96FD");

            entity.ToTable("cart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Customer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__cart__customerId__4316F928");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__cart__productId__440B1D61");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3213E83F692BA841");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .HasColumnName("content");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("updateAt");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83F9361EAE2");

            entity.ToTable("customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.Img)
                .HasMaxLength(200)
                .HasColumnName("img");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.RandomKey)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("randomKey");
            entity.Property(e => e.RegisteredAt)
                .HasColumnType("datetime")
                .HasColumnName("registeredAt");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("updateAt");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payment__3213E83F892ABF39");

            entity.ToTable("payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Customer).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__payment__custome__44FF419A");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("paymentDetail");

            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.PaymentId).HasColumnName("paymentId");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Payment).WithMany()
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__paymentDe__payme__45F365D3");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__paymentDe__produ__46E78A0C");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__post__3213E83F6E7424FD");

            entity.ToTable("post");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Img)
                .HasMaxLength(200)
                .HasColumnName("img");
            entity.Property(e => e.IsApproved)
                .HasDefaultValue(false)
                .HasColumnName("isApproved");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("updateAt");

            entity.HasOne(d => d.Customer).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post__customerId__47DBAE45");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3213E83F71E98957");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .HasColumnName("content");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.Img)
                .HasMaxLength(200)
                .HasColumnName("img");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("updateAt");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__product__categor__48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
