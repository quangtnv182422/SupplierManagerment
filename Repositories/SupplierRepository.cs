using DataAccessObjects;
using DataAccessObjects.BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public void AddSupplier(Supplier supplier) => SupplierDAO.AddSupplier(supplier);

        public void DeleteSupplier(Supplier supplier) => SupplierDAO.DeleteSupplier(supplier);


        public List<Supplier> GetAllSupplier() => SupplierDAO.GetAllSupplier();


        public Supplier GetSupplierById(int id) => SupplierDAO.GetSupplierById(id);


        public void UpdateSupplier(Supplier supplier) => SupplierDAO.UpdateSupplier(supplier);

    }
}
