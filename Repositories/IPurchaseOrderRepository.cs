using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IPurchaseOrderRepository
    {
        List<PurchaseOrder> GetAllPurchaseOrder();
        void AddPurchaseOrder(PurchaseOrder purchaseOrder);
        void DeletePurchaseOrder(PurchaseOrder purchaseOrder);
        void UpdatePurchaseOrder(PurchaseOrder purchaseOrder);
        PurchaseOrder GetPurchaseOrderById(int id);

    }
}
