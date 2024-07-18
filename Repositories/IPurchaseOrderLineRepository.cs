using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IPurchaseOrderLineRepository
    {
        List<PurchaseOrderLine> GetAllPurchaseOrderLine();
        void AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine);
        void UpdatePurchaseOrderLine(PurchaseOrderLine purchaseOrderLine);
        void DeletePurchaseOrderLine(PurchaseOrderLine purchaseOrderLine);
        PurchaseOrderLine GetPurchaseOrderLineById(int id);
    }
}
