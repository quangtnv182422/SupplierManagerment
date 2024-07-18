using DataAccessObjects.BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PurchaseOrderLineService : IPurchaseOrderLineService
    {
        private readonly IPurchaseOrderLineRepository _purchaseOrderLineRepository;

        public PurchaseOrderLineService(IPurchaseOrderLineRepository purchaseOrderLineRepository)
        {
            _purchaseOrderLineRepository = purchaseOrderLineRepository;
        }

        public void AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine)
        {
            if (purchaseOrderLine == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrderLine));
            }
            _purchaseOrderLineRepository.AddPurchaseOrderLine(purchaseOrderLine);
        }

        public void DeletePurchaseOrderLine(PurchaseOrderLine purchaseOrderLine)
        {
            if (purchaseOrderLine == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrderLine));
            }
            _purchaseOrderLineRepository.DeletePurchaseOrderLine(purchaseOrderLine);
        }

        public List<PurchaseOrderLine> GetAllPurchaseOrderLines()
        {
            return _purchaseOrderLineRepository.GetAllPurchaseOrderLine();
        }

        public PurchaseOrderLine GetPurchaseOrderLineById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid purchase order line ID", nameof(id));
            }
            return _purchaseOrderLineRepository.GetPurchaseOrderLineById(id);
        }

        public void UpdatePurchaseOrderLine(PurchaseOrderLine purchaseOrderLine)
        {
            if (purchaseOrderLine == null)
            {
                throw new ArgumentNullException(nameof(purchaseOrderLine));
            }
            _purchaseOrderLineRepository.UpdatePurchaseOrderLine(purchaseOrderLine);
        }


        public List<PurchaseOrderLine> GetPurchaseOrderLinesByProductId(int productId)
        {
            var purchaseOrderLines = _purchaseOrderLineRepository.GetAllPurchaseOrderLine();
            return purchaseOrderLines.Where(pol => pol.ProductId == productId).ToList();
        }

        public List<PurchaseOrderLine> GetPurchaseOrderLinesSortedByQuantity()
        {
            var purchaseOrderLines = _purchaseOrderLineRepository.GetAllPurchaseOrderLine();
            return purchaseOrderLines.OrderBy(pol => pol.OrderedQuantity).ToList();
        }

        public List<PurchaseOrderLine> GetPurchaseOrderLinesByReceiptDate(DateTime startDate, DateTime endDate)
        {
            var purchaseOrderLines = _purchaseOrderLineRepository.GetAllPurchaseOrderLine();
            return purchaseOrderLines
                .Where(pol => pol.LastReceiptDate.HasValue &&
                              pol.LastReceiptDate.Value.ToDateTime(new TimeOnly(0, 0)) >= startDate &&
                              pol.LastReceiptDate.Value.ToDateTime(new TimeOnly(0, 0)) <= endDate)
                .ToList();
        }
    }
}
