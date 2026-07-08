using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Services.Interface;

namespace InventoryManagement.Services.Implementation;

public class PurchaseService(IUnitOfWork uow, IMapper mapper) : IPurchaseService
{
    public async Task CreatePurchaseOrder(CreatePurchaseOrderDTO dto)
    {
        var purchaseorder = mapper.Map<PurchaseOrder>(dto);
        purchaseorder.OrderDate = DateTime.Now;
        purchaseorder.Status = OrderStatus.Pending;
        await uow.PurchaseRepo.CreateAsync(purchaseorder);
        await uow.SaveChangesAllAsync();
    }

    public async Task<IEnumerable<ResponseOrderPurchaseDTO>> GetAllOrders()
    {
        var result = await uow.PurchaseRepo.GetAllAsync();
        return mapper.Map<IEnumerable< ResponseOrderPurchaseDTO>>(result);
    }

    public Task<ResponseOrderPurchaseDTO> GetPurchaseOrderById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public async Task RecievePurchaseOrder(Guid PurchaseOrderId)
    {
        var purchaseorder = await uow.PurchaseRepo.GetPurchaseOrderDetailsAsync(PurchaseOrderId);
        if(purchaseorder.Status == OrderStatus.Received)
        {
            throw new Exception("Order Already Received");
        }
        foreach(var x in purchaseorder.PurchaseOrderItems)
        {
            var inventory =await uow.InventoryRepo.GetInventoryAsync(x.ProductId,purchaseorder.WareHouseId);
            if(inventory == null)
            {
                inventory = new Inventory
                {
                    ProductId = x.ProductId,
                    WareHouseId = purchaseorder.WareHouseId,
                    Quantity = x.Quantity
                };
                await uow.InventoryRepo.CreateAsync(inventory);
            }
            else
            {
                inventory.Quantity = x.Quantity;
                await uow.InventoryRepo.UpdateAsync(inventory);
            }

            var record = new RecordTransaction
            {
                ProductId = x.ProductId,
                WareHouseId = purchaseorder.WareHouseId,
                Quantity = x.Quantity,
                TransactionDate = DateTime.Now,
                Type = TransactionType.PurchaseReceipt,
                Description = "Purchase order Received",
            };
            await uow.RecordRepo.CreateAsync(record);
        }

        purchaseorder.Status = OrderStatus.Received;
        await uow.PurchaseRepo.UpdateAsync(purchaseorder);
        await uow.SaveChangesAllAsync();
    }
}
