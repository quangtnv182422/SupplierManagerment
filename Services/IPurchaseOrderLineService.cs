using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPurchaseOrderLineService
    {
        void AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine);
        void DeletePurchaseOrderLine(PurchaseOrderLine purchaseOrderLine);
        List<PurchaseOrderLine> GetAllPurchaseOrderLines();
        PurchaseOrderLine GetPurchaseOrderLineById(int id);
        void UpdatePurchaseOrderLine(PurchaseOrderLine purchaseOrderLine);
        List<PurchaseOrderLine> GetPurchaseOrderLinesByProductId(int productId);
        List<PurchaseOrderLine> GetPurchaseOrderLinesSortedByQuantity();
        List<PurchaseOrderLine> GetPurchaseOrderLinesByReceiptDate(DateTime startDate, DateTime endDate);
    }
}
