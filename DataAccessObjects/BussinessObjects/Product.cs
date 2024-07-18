using System;
using System.Collections.Generic;

namespace DataAccessObjects.BussinessObjects;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? SupplierId { get; set; }

    public string? Color { get; set; }

    public string? PackageType { get; set; }

    public string? Size { get; set; }

    public decimal? TaxRate { get; set; }

    public decimal? UnitPrice { get; set; }

    public decimal? RecommendedRetailPrice { get; set; }

    public decimal? TypicalWeightPerUnit { get; set; }

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();

    public virtual Supplier? Supplier { get; set; }
}
