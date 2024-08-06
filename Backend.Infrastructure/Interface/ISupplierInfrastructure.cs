using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Interface
{
    public interface ISupplierInfrastructure
    {
        public Task<List<Supplier>> GetAllAsync();
        public Task<bool> SaveAsync(Supplier supplier);
        public Task<bool> UpdateAsync(int id, Supplier supplier);
        public Task<bool> DeleteAsync(int id);
    }
}
