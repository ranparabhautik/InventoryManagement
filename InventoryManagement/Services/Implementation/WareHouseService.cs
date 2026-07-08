using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Services.Interface;

namespace InventoryManagement.Services.Implementation;

public class WareHouseService(IUnitOfWork uow,IMapper mapper) : IWareHouseService
{
    public async Task CreateWareHouse(CreateWareHouseDTO dto)
    {
        var warehouse = mapper.Map<WareHouse>(dto);
        await uow.WareHouseRepo.CreateAsync(warehouse);
        await uow.SaveChangesAllAsync();
    }

    public async Task DeleteWareHouse(Guid Id)
    {
        var existing = await uow.WareHouseRepo.GetByIdAsync(Id);
        if(existing == null) { throw new Exception("Warehouse Not Found"); }
        await uow.WareHouseRepo.DeleteAsync(Id);
        await uow.SaveChangesAllAsync();
    }

    public async Task<IEnumerable<ResponseWareHouseDTO>> GetAllWareHouse()
    {
        var warehouses = await uow.WareHouseRepo.GetAllAsync();
        return mapper.Map<IEnumerable<ResponseWareHouseDTO>>(warehouses);
    }

    public async Task<ResponseWareHouseDTO?> GetWareHouseById(Guid Id)
    {
        var warehouse = await uow.WareHouseRepo.GetByIdAsync(Id);
        if (warehouse == null) { throw new Exception("Warehouse Not Found"); }
        return mapper.Map<ResponseWareHouseDTO>(warehouse);
    }

    public async Task UpdateWareHouse(Guid Id, UpdateWareHouseDTO dto)
    {
        var warehouse = await uow.WareHouseRepo.GetByIdAsync(Id);
        if (warehouse == null) { throw new Exception("Warehouse Not Found"); }
        var result = mapper.Map(dto, warehouse);
        await uow.WareHouseRepo.UpdateAsync(result);
        await uow.SaveChangesAllAsync();
    }
}
