using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISupplierRepository
    {
        List<Supplier> GetAllSupplier();
        void AddSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        Supplier GetSupplierById(int id);
    }
}
