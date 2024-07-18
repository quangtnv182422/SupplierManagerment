using System;
using System.Collections.Generic;

namespace DataAccessObjects.BussinessObjects;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public int? SupplierCategoryId { get; set; }

    public string? DeliveryMethod { get; set; }

    public string? DeliveryCity { get; set; }

    public string? SupplierReference { get; set; }

    public string? BankAccountName { get; set; }

    public string? BankAccountBranch { get; set; }

    public string? BankAccountCode { get; set; }

    public string? BankAccountNumber { get; set; }

    public string? BankInternationalCode { get; set; }

    public int? PaymentDays { get; set; }

    public string? PhoneNumber { get; set; }

    public string? FaxNumber { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? DeliveryAddressLine1 { get; set; }

    public string? DeliveryAddressLine2 { get; set; }

    public string? DeliveryPostalCode { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    public virtual SupplierCategory? SupplierCategory { get; set; }

    public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; } = new List<SupplierTransaction>();
}
