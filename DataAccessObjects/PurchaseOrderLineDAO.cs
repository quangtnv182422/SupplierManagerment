using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class PurchaseOrderLineDAO
    {

        public static List<PurchaseOrderLine> GetAllPurchaseOrderLine()
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            return context.PurchaseOrderLines.ToList();
        }
        public static void AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (purchaseOrderLine == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrderLine));
            }
            else
            {
                context.PurchaseOrderLines.Add(purchaseOrderLine);
                context.SaveChanges();
            }
        }

        public static void DeletePurchaseOrderLine(PurchaseOrderLine purchaseOrderLine)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (purchaseOrderLine == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrderLine));
            }
            else
            {
                context.PurchaseOrderLines.Remove(purchaseOrderLine);
                context.SaveChanges();
            }
        }

        public static void UpdatePurchaseOrderLine(PurchaseOrderLine purchaseOrderLine)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (purchaseOrderLine == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrderLine));
            }
            else
            {
                context.PurchaseOrderLines.Update(purchaseOrderLine);
                context.SaveChanges();
            }
        }

        public static PurchaseOrderLine GetPurchaseOrderLineById(int id)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            var purchaseOrderLine = (from p in context.PurchaseOrderLines
                                     where p.PurchaseOrderLineId == id
                                     select p).FirstOrDefault();
            return purchaseOrderLine;
        }
    }
}
