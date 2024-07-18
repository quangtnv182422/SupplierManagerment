using DataAccessObjects;
using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        public void AddPurchaseOrder(PurchaseOrder purchaseOrder) => PurchaseOrderDAO.AddPurchaseOrder(purchaseOrder);


        public void DeletePurchaseOrder(PurchaseOrder purchaseOrder) => PurchaseOrderDAO.DeletePurchaseOrder(purchaseOrder);


        public List<PurchaseOrder> GetAllPurchaseOrder() => PurchaseOrderDAO.GetAllPurchaseOrder();


        public PurchaseOrder GetPurchaseOrderById(int id) => PurchaseOrderDAO.GetPurchaseOrderById(id);


        public void UpdatePurchaseOrder(PurchaseOrder purchaseOrder) => PurchaseOrderDAO.UpdatePurchaseOrder(purchaseOrder);    

    }
}
