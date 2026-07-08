using InventoryManagement.DTOs;

namespace InventoryManagement.Services.Interface;

public interface ISupplierService
{
    Task<IEnumerable<ResponseSupplierDTO>> GetAllSupplier();
    Task<ResponseSupplierDTO?> GetSupplierById(Guid Id);
    Task CreateSupplier(CreateSupplierDTO dto);
    Task UpdateSupplier(Guid Id,UpdateSupplierDTO dto);
    Task DeleteSupplier(Guid Id);
}
