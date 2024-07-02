using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DBContext;

public partial class ThoiTrangContext : DbContext
{
    public ThoiTrangContext()
    {
    }

    public ThoiTrangContext(DbContextOptions<ThoiTrangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiscountCode> DiscountCodes { get; set; }

    public virtual DbSet<Notice> Notices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiscountCode>(entity =>
        {
            entity.HasKey(e => e.DiscountCode1).HasName("PK__discount__75C1F0071845DA2F");

            entity.ToTable("discount_code");

            entity.Property(e => e.DiscountCode1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("discount_code");
            entity.Property(e => e.DiscountDescription)
                .HasColumnType("text")
                .HasColumnName("discount_description");
            entity.Property(e => e.DiscountEndDate)
                .HasColumnType("date")
                .HasColumnName("discount_end_date");
            entity.Property(e => e.DiscountName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("discount_name");
            entity.Property(e => e.DiscountStartDate)
                .HasColumnType("date")
                .HasColumnName("discount_start_date");
            entity.Property(e => e.DiscountStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("discount_status");
            entity.Property(e => e.DiscountType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("discount_type");
            entity.Property(e => e.DiscountValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount_value");
        });

        modelBuilder.Entity<Notice>(entity =>
        {
            entity.HasKey(e => e.NoticeId).HasName("PK__notice__3E82A5DBE9B64072");

            entity.ToTable("notice");

            entity.Property(e => e.NoticeId).HasColumnName("notice_id");
            entity.Property(e => e.NoticeContent)
                .HasColumnType("text")
                .HasColumnName("notice_content");
            entity.Property(e => e.NoticeStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("notice_status");
            entity.Property(e => e.NoticeTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("notice_title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_notice_users");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__465962292AC60F6D");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("order_status");
            entity.Property(e => e.OrderTotalAmount)
                .HasColumnType("float")
                .HasColumnName("order_total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__order_it__3764B6BCD7A53B3B");

            entity.ToTable("order_item");

            entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Price)
                .HasColumnType("float")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__payment__ED1FC9EA4B2B8A33");

            entity.ToTable("payment");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.OrderDetails)
                .HasColumnType("text")
                .HasColumnName("order_details");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderPaymentMethod)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("order_payment_method");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("order_status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

          
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__product__47027DF58543E257");

            entity.ToTable("product");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductBrand)
                .HasMaxLength(255)
                .HasColumnName("product_brand");
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(255)
                .HasColumnName("product_category");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(255)
                .HasColumnName("product_code");
            entity.Property(e => e.ProductDescription)
                .HasColumnType("text")
                .HasColumnName("product_description");
            entity.Property(e => e.ProductImage)
                .HasMaxLength(255)
                .HasColumnName("product_image");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("product_price");
            entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");
            entity.Property(e => e.ProductStatus)
                .HasMaxLength(255)
                .HasColumnName("product_status");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__roles__760965CC8F4EF5B5");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsersId).HasName("PK__users__EAA7D14B28B88DFA");

            entity.ToTable("users");

            entity.Property(e => e.UsersId).HasColumnName("users_id");
            entity.Property(e => e.Passwords)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("passwords");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UsersAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("users_address");
            entity.Property(e => e.UsersEmail)
                .HasMaxLength(255)
                .HasColumnName("users_email");
            entity.Property(e => e.UsersName)
                .HasMaxLength(255)
                .HasColumnName("users_name");
            entity.Property(e => e.UsersPhone)
                .HasMaxLength(255)
                .HasColumnName("users_phone");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
