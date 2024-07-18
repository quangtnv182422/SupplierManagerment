using DataAccessObjects;
using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PurchaseOrderLineRepository : IPurchaseOrderLineRepository
    {
        public void AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine) => PurchaseOrderLineDAO.AddPurchaseOrderLine(purchaseOrderLine);


        public void DeletePurchaseOrderLine(PurchaseOrderLine purchaseOrderLine) => PurchaseOrderLineDAO.DeletePurchaseOrderLine(purchaseOrderLine);


        public List<PurchaseOrderLine> GetAllPurchaseOrderLine() => PurchaseOrderLineDAO.GetAllPurchaseOrderLine();


        public PurchaseOrderLine GetPurchaseOrderLineById(int id) => PurchaseOrderLineDAO.GetPurchaseOrderLineById(id);


        public void UpdatePurchaseOrderLine(PurchaseOrderLine purchaseOrderLine) => PurchaseOrderLineDAO.UpdatePurchaseOrderLine(purchaseOrderLine);

    }
}
