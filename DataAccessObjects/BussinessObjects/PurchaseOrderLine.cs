using System;
using System.Collections.Generic;

namespace DataAccessObjects.BussinessObjects;

public partial class PurchaseOrderLine
{
    public int PurchaseOrderLineId { get; set; }

    public int? PurchaseOrderId { get; set; }

    public int? ProductId { get; set; }

    public int? OrderedQuantity { get; set; }

    public string? Description { get; set; }

    public int? ReceivedQuantity { get; set; }

    public DateOnly? LastReceiptDate { get; set; }

    public bool? IsOrderLineFinalized { get; set; }

    public virtual Product? Product { get; set; }

    public virtual PurchaseOrder? PurchaseOrder { get; set; }
}
