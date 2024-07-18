using System;
using System.Collections.Generic;

namespace DataAccessObjects.BussinessObjects;

public partial class SupplierCategory
{
    public int SupplierCategoryId { get; set; }

    public string? SupplierCategoryName { get; set; }

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
