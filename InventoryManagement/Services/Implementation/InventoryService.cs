using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Services.Interface;

namespace InventoryManagement.Services.Implementation;

public class InventoryService(IUnitOfWork uow,IMapper mapper) : IInventoryService
{
    public async Task<IEnumerable<ResponseInventoryDTO>> GetAllInventory()
    {
        var inventory = await uow.InventoryRepo.GetAllAsync();
        return mapper.Map<IEnumerable<ResponseInventoryDTO>>(inventory);
    }

    public async Task<ResponseInventoryDTO> GetInventory(Guid ProductId, Guid WarehouseId)
    {
        var inventory = await uow.InventoryRepo.GetInventoryAsync(ProductId,WarehouseId);
        if (inventory == null) { throw new Exception("Inventory not found"); }
        return mapper.Map<ResponseInventoryDTO>(inventory);
    }

    public async Task StockIn(StockDTO dto)
    {
        var inventory = await uow.InventoryRepo.GetInventoryAsync(dto.ProductId, dto.WareHouseId);
        if(inventory == null)
        {
            inventory = new Model.Inventory
            {
                ProductId = dto.ProductId,
                WareHouseId = dto.WareHouseId,
                Quantity = dto.Quantity
            };
            await uow.InventoryRepo.CreateAsync(inventory);
        }
        else
        {
            inventory.Quantity += dto.Quantity;
            await uow.InventoryRepo.UpdateAsync(inventory);
        }
        var record = new RecordTransaction
        {
            ProductId = dto.ProductId,
            WareHouseId = dto.WareHouseId,
            Quantity = dto.Quantity,
            Type = TransactionType.StockIn,
            Description = dto.Description,
            TransactionDate = DateTime.Now
        };
        await uow.RecordRepo.CreateAsync(record);
        await uow.SaveChangesAllAsync();
    }

    public async Task StockOut(StockDTO dto)
    {
        var inventory = await uow.InventoryRepo.GetInventoryAsync(dto.ProductId, dto.WareHouseId);
        if(inventory == null)
        {
            throw new Exception("Inventory not found");
        }
        if(inventory.Quantity < dto.Quantity)
        {
            throw new Exception("Quantity is less ");
        }
        inventory.Quantity -= dto.Quantity;
        await uow.InventoryRepo.UpdateAsync(inventory);

        var record = new RecordTransaction
        {
            ProductId = dto.ProductId,
            WareHouseId = dto.WareHouseId,
            Quantity = dto.Quantity,
            Type = TransactionType.StockOut,
            Description = dto.Description,
            TransactionDate = DateTime.Now
        };
        await uow.RecordRepo.CreateAsync(record);
        await uow.SaveChangesAllAsync();
    }

    public async Task TransferStock(TransferStockDTO dto)
    {
        if(dto.ToWarehouseId == dto.FromWareHouseId) { throw new Exception("Destination can not be same"); }
        var sourceinventory = await uow.InventoryRepo.GetInventoryAsync(dto.ProductId, dto.FromWareHouseId);
        if (sourceinventory == null) { throw new Exception("Inventory Not found"); }
        if(sourceinventory.Quantity < dto.Quantity) { throw new Exception("Insufficient Stock"); }

        var destinationInventory = await uow.InventoryRepo.GetInventoryAsync(dto.ProductId, dto.ToWarehouseId);
        if (destinationInventory == null)
        {
            destinationInventory = new Inventory
            {   
                ProductId = dto.ProductId,
                WareHouseId = dto.ToWarehouseId,
                Quantity = dto.Quantity,
            };
            await uow.InventoryRepo.UpdateAsync(destinationInventory);
        }
        else
        {
            destinationInventory.Quantity += dto.Quantity;
            await uow.InventoryRepo.UpdateAsync(destinationInventory);
        }
        sourceinventory.Quantity -= dto.Quantity;
        await uow.InventoryRepo.UpdateAsync(sourceinventory);

        var transferOutRecord = new RecordTransaction
        {
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            Description = dto.Description,
            TransactionDate = DateTime.Now,
            WareHouseId = dto.FromWareHouseId,
            Type = TransactionType.TransferOut,
        };
        var transferInRecord = new RecordTransaction
        {
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            Description = dto.Description,
            TransactionDate = DateTime.Now,
            WareHouseId = dto.ToWarehouseId,
            Type = TransactionType.TransferIn,
        };

        await uow.RecordRepo.CreateAsync(transferOutRecord);
        await uow.RecordRepo.CreateAsync(transferInRecord);

        await uow.SaveChangesAllAsync();
    }
}
