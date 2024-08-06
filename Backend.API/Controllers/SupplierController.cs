using AutoMapper;
using Backend.API.Request;
using Backend.API.Response;
using Backend.Infrastructure.Interface;
using Backend.Infrastructure.Models;
using Backend.Infrastructure.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISupplierInfrastructure _supplierInfrastructure;

        public SupplierController(IMapper mapper, ISupplierInfrastructure supplierInfrastructure)
        {
            _mapper = mapper;
            _supplierInfrastructure = supplierInfrastructure;
        }

        // GET api/supplier
        [HttpGet]
        public async Task<List<SupplierResponse>> GetAllAsync()
        {
            var suppliers = await _supplierInfrastructure.GetAllAsync();
            var suppliersResponse = _mapper.Map<List<Supplier>, List<SupplierResponse>>(suppliers);
            return suppliersResponse;

        }

        [HttpPost]
        public async Task PostAsync([FromBody] SupplierRequest request)
        {
            if (ModelState.IsValid)
            {
                var supplier = _mapper.Map<SupplierRequest, Supplier>(request);

                await _supplierInfrastructure.SaveAsync(supplier);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT 
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] SupplierRequest request)
        {
            if (ModelState.IsValid)
            {
                var supplier = _mapper.Map<SupplierRequest, Supplier>(request);
                supplier.Id = id;
                await _supplierInfrastructure.UpdateAsync(id, supplier);
            }
            else
            {
                StatusCode(400);
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _supplierInfrastructure.DeleteAsync(id);
        }

    }
}
