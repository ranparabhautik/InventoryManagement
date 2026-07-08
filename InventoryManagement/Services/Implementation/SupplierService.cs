using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Services.Interface;

namespace InventoryManagement.Services.Implementation;

public class SupplierService(IUnitOfWork uow,IMapper mapper) : ISupplierService
{
    public async Task CreateSupplier(CreateSupplierDTO dto)
    {
        var supplier = mapper.Map<Supplier>(dto);
        await uow.SupplierRepo.CreateAsync(supplier);
        await uow.SaveChangesAllAsync();
    }

    public async Task DeleteSupplier(Guid Id)
    {
        var supplier = await uow.SupplierRepo.GetByIdAsync(Id);
        if (supplier == null) { throw new Exception("Supplier Not Found"); }
        await uow.SupplierRepo.DeleteAsync(Id);
        await uow.SaveChangesAllAsync();
    }

    public async Task<IEnumerable<ResponseSupplierDTO>> GetAllSupplier()
    {
        var Result = await uow.SupplierRepo.GetAllAsync();
        return mapper.Map<IEnumerable< ResponseSupplierDTO>>(Result);
    }

    public async Task<ResponseSupplierDTO?> GetSupplierById(Guid Id)
    {
        var result = await uow.SupplierRepo.GetByIdAsync(Id);
        if (result == null) { throw new Exception("Supplier Not Found"); }
        return mapper.Map<ResponseSupplierDTO>(result);
    }

    public async Task UpdateSupplier(Guid Id,UpdateSupplierDTO dto)
    {
        var supplier = await uow.SupplierRepo.GetByIdAsync(Id);
        if (supplier == null) { throw new Exception("Supplier Not Found"); }
        var result = mapper.Map(dto,supplier);
        await uow.SupplierRepo.UpdateAsync(supplier);
        await uow.SaveChangesAllAsync();

    }
}
