using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class PurchaseOrderDAO
    {

        public static List<PurchaseOrder> GetAllPurchaseOrder()
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            return context.PurchaseOrders.ToList();
        }
        public static void AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (purchaseOrder == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrder));
            }
            else
            {
                context.PurchaseOrders.Add(purchaseOrder);
                context.SaveChanges();
            }
        }

        public static void DeletePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (purchaseOrder == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrder));
            }
            else
            {
                context.PurchaseOrders.Remove(purchaseOrder);
                context.SaveChanges();
            }
        }

        public static void UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            if (purchaseOrder == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrder));
            }
            else
            {
                context.PurchaseOrders.Update(purchaseOrder);
                context.SaveChanges();
            }
        }

        public static PurchaseOrder GetPurchaseOrderById(int id)
        {
            SupplierManagementDbContext context = new SupplierManagementDbContext();
            var purchaseOrder = (from p in context.PurchaseOrders
                                 where p.PurchaseOrderId == id
                                 select p).FirstOrDefault();
            return purchaseOrder;
        }
    }
}
