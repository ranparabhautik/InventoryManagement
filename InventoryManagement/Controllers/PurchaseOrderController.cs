using InventoryManagement.DTOs;
using InventoryManagement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchaseOrderController(IPurchaseService _service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllOrders();
        return Ok(result);
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _service.GetPurchaseOrderById(Id);
        return Ok(result);
    }

    [HttpPost] 
    public async Task<IActionResult> Create(CreatePurchaseOrderDTO dto) 
    {
        await _service.CreatePurchaseOrder(dto);
        return Ok("Purchase Order Created Succesfully");
    }

    [HttpPut("receive/{Id:guid}")]
    public async Task<IActionResult> ReceiveOrder(Guid Id)
    {
        await _service.RecievePurchaseOrder(Id);
        return Ok("Purchase Order Received ");
    }
}
