using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessObjects.BussinessObjects;

public partial class SupplierManagementDbContext : DbContext
{
    public SupplierManagementDbContext()
    {
    }

    public SupplierManagementDbContext(DbContextOptions<SupplierManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountMember> AccountMembers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierCategory> SupplierCategories { get; set; }

    public virtual DbSet<SupplierTransaction> SupplierTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfiguration configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
    /*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=LAPTOP-BSF7CSMP;database=SupplierManagementDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountMember>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__AccountM__0CF04B38032C433A");

            entity.ToTable("AccountMember");

            entity.Property(e => e.MemberId)
                .HasMaxLength(20)
                .HasColumnName("MemberID");
            entity.Property(e => e.EmailAddress).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(80);
            entity.Property(e => e.MemberPassword).HasMaxLength(80);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED831EC5F4");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.PackageType).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.RecommendedRetailPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Size).HasMaxLength(20);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.TaxRate).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TypicalWeightPerUnit).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__Products__Suppli__412EB0B6");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderId).HasName("PK__Purchase__036BAC44762A140D");

            entity.Property(e => e.PurchaseOrderId)
                .ValueGeneratedNever()
                .HasColumnName("PurchaseOrderID");
            entity.Property(e => e.DeliveryMethod).HasMaxLength(50);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.SupplierReference).HasMaxLength(20);

            entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__PurchaseO__Suppl__440B1D61");
        });

        modelBuilder.Entity<PurchaseOrderLine>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderLineId).HasName("PK__Purchase__2100B0182E8339DC");

            entity.Property(e => e.PurchaseOrderLineId)
                .ValueGeneratedNever()
                .HasColumnName("PurchaseOrderLineID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__PurchaseO__Produ__4222D4EF");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.PurchaseOrderId)
                .HasConstraintName("FK__PurchaseO__Purch__4316F928");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE66694A1B619CE");

            entity.Property(e => e.SupplierId)
                .ValueGeneratedNever()
                .HasColumnName("SupplierID");
            entity.Property(e => e.BankAccountBranch).HasMaxLength(50);
            entity.Property(e => e.BankAccountCode).HasMaxLength(20);
            entity.Property(e => e.BankAccountName).HasMaxLength(50);
            entity.Property(e => e.BankAccountNumber).HasMaxLength(20);
            entity.Property(e => e.BankInternationalCode).HasMaxLength(20);
            entity.Property(e => e.DeliveryAddressLine1).HasMaxLength(60);
            entity.Property(e => e.DeliveryAddressLine2).HasMaxLength(60);
            entity.Property(e => e.DeliveryCity).HasMaxLength(50);
            entity.Property(e => e.DeliveryMethod).HasMaxLength(50);
            entity.Property(e => e.DeliveryPostalCode).HasMaxLength(10);
            entity.Property(e => e.FaxNumber).HasMaxLength(20);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.SupplierCategoryId).HasColumnName("SupplierCategoryID");
            entity.Property(e => e.SupplierName).HasMaxLength(100);
            entity.Property(e => e.SupplierReference).HasMaxLength(20);
            entity.Property(e => e.WebsiteUrl)
                .HasMaxLength(256)
                .HasColumnName("WebsiteURL");

            entity.HasOne(d => d.SupplierCategory).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.SupplierCategoryId)
                .HasConstraintName("FK__Suppliers__Suppl__44FF419A");
        });

        modelBuilder.Entity<SupplierCategory>(entity =>
        {
            entity.HasKey(e => e.SupplierCategoryId).HasName("PK__Supplier__50E4495081DE457D");

            entity.Property(e => e.SupplierCategoryId)
                .ValueGeneratedNever()
                .HasColumnName("SupplierCategoryID");
            entity.Property(e => e.SupplierCategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<SupplierTransaction>(entity =>
        {
            entity.HasKey(e => e.SupplierTransactionId).HasName("PK__Supplier__E905F1591BBE1A1E");

            entity.Property(e => e.SupplierTransactionId)
                .ValueGeneratedNever()
                .HasColumnName("SupplierTransactionID");
            entity.Property(e => e.AmountExcludingTax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.SupplierInvoiceNumber).HasMaxLength(20);
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionType).HasMaxLength(50);

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.SupplierTransactions)
                .HasForeignKey(d => d.PurchaseOrderId)
                .HasConstraintName("FK__SupplierT__Purch__45F365D3");

            entity.HasOne(d => d.Supplier).WithMany(p => p.SupplierTransactions)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__SupplierT__Suppl__46E78A0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
