using System;
using System.Collections.Generic;

namespace DataAccessObjects.BussinessObjects;

public partial class SupplierTransaction
{
    public int SupplierTransactionId { get; set; }

    public int? SupplierId { get; set; }

    public string TransactionType { get; set; } = null!;

    public int? PurchaseOrderId { get; set; }

    public string? PaymentMethod { get; set; }

    public string? SupplierInvoiceNumber { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public decimal? AmountExcludingTax { get; set; }

    public decimal? TaxAmount { get; set; }

    public decimal? TransactionAmount { get; set; }

    public DateOnly? FinalizationDate { get; set; }

    public bool? IsFinalized { get; set; }

    public virtual PurchaseOrder? PurchaseOrder { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
