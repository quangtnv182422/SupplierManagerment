using DataAccessObjects.BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public void AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrder));
            }
            _purchaseOrderRepository.AddPurchaseOrder(purchaseOrder);
        }

        public void DeletePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrder));
            }
            _purchaseOrderRepository.DeletePurchaseOrder(purchaseOrder);
        }

        public List<PurchaseOrder> GetAllPurchaseOrders()
        {
            return _purchaseOrderRepository.GetAllPurchaseOrder();
        }

        public PurchaseOrder GetPurchaseOrderById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid purchase order ID", nameof(id));
            }
            return _purchaseOrderRepository.GetPurchaseOrderById(id);
        }

        public void UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrder));
            }
            _purchaseOrderRepository.UpdatePurchaseOrder(purchaseOrder);
        }


        public List<PurchaseOrder> GetPurchaseOrdersBySupplierId(int supplierId)
        {
            var purchaseOrders = _purchaseOrderRepository.GetAllPurchaseOrder();
            return purchaseOrders.Where(po => po.SupplierId == supplierId).ToList();
        }

        public List<PurchaseOrder> GetPurchaseOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            var purchaseOrders = _purchaseOrderRepository.GetAllPurchaseOrder();
            return purchaseOrders
                .Where(po => po.OrderDate.ToDateTime(new TimeOnly(0, 0)) >= startDate &&
                             po.OrderDate.ToDateTime(new TimeOnly(0, 0)) <= endDate)
                .ToList();
        }

        public List<PurchaseOrder> GetPurchaseOrdersSortedByExpectedDeliveryDate()
        {
            var purchaseOrders = _purchaseOrderRepository.GetAllPurchaseOrder();
            return purchaseOrders
                .Where(po => po.ExpectedDeliveryDate.HasValue)
                .OrderBy(po => po.ExpectedDeliveryDate.Value.ToDateTime(new TimeOnly(0, 0)))
                .ToList();
        }

        public List<PurchaseOrder> GetPurchaseOrderByExpectedDeliveryDate(DateTime startDate, DateTime endDate)
        {
            var purchaseOrderLines = _purchaseOrderRepository.GetAllPurchaseOrder();
            return purchaseOrderLines
                .Where(pol => pol.ExpectedDeliveryDate.HasValue &&
                              pol.ExpectedDeliveryDate.Value.ToDateTime(new TimeOnly(0, 0)) >= startDate &&
                              pol.ExpectedDeliveryDate.Value.ToDateTime(new TimeOnly(0, 0)) <= endDate)
                .ToList();
        }
    }
}
