using Backend.Infrastructure.Context;
using Backend.Infrastructure.Interface;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Services
{
    public class SupplierInfrastructure : ISupplierInfrastructure
    {
        public readonly EYDbContext _context;
        public SupplierInfrastructure(EYDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var supplierToDelete = await _context.Supplier.FirstOrDefaultAsync(u => u.Id == id);
            if (supplierToDelete != null)
            {
                _context.Supplier.Remove(supplierToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            var suppliers = await _context.Supplier.ToListAsync();
            return suppliers;
        }

        public async Task<bool> SaveAsync(Supplier supplier)
        {
            await _context.Supplier.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, Supplier supplier)
        {
            var supplierToUpdate = await _context.Supplier.FindAsync(id);
            if (supplierToUpdate != null)
            {
                supplierToUpdate.razonSocial = supplier.razonSocial;
                supplierToUpdate.nombreComercial = supplier.nombreComercial;
                supplierToUpdate.identificacionTributaria = supplier.identificacionTributaria;
                supplierToUpdate.numeroTelefonico = supplier.numeroTelefonico;
                supplierToUpdate.email = supplier.email;
                supplierToUpdate.sitioWeb = supplier.sitioWeb;
                supplierToUpdate.direccionFisica = supplier.direccionFisica;
                supplierToUpdate.pais = supplier.pais;
                supplierToUpdate.facturacionAnual = supplier.facturacionAnual;
                supplierToUpdate.ultimaModificacion = DateTime.Now;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
