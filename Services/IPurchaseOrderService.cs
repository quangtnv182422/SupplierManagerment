using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPurchaseOrderService
    {
        void AddPurchaseOrder(PurchaseOrder purchaseOrder);
        void DeletePurchaseOrder(PurchaseOrder purchaseOrder);
        List<PurchaseOrder> GetAllPurchaseOrders();
        PurchaseOrder GetPurchaseOrderById(int id);
        void UpdatePurchaseOrder(PurchaseOrder purchaseOrder);
        List<PurchaseOrder> GetPurchaseOrdersBySupplierId(int supplierId);
        List<PurchaseOrder> GetPurchaseOrdersByDateRange(DateTime startDate, DateTime endDate);
        List<PurchaseOrder> GetPurchaseOrdersSortedByExpectedDeliveryDate();
    }
}
