using System;
using System.Collections.Generic;

namespace DataAccessObjects.BussinessObjects;

public partial class PurchaseOrder
{
    public int PurchaseOrderId { get; set; }

    public int? SupplierId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string? DeliveryMethod { get; set; }

    public DateOnly? ExpectedDeliveryDate { get; set; }

    public string? SupplierReference { get; set; }

    public bool IsOrderFinalized { get; set; }

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();

    public virtual Supplier? Supplier { get; set; }

    public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; } = new List<SupplierTransaction>();
}
