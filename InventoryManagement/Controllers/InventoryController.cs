using InventoryManagement.DTOs;
using InventoryManagement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryController(IInventoryService _service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllInventory();
        return Ok(result);
    }

    [HttpGet("{productId:guid} /{ warehouseId:guid}")]
    public async Task<IActionResult> GetById(Guid productId, Guid warehouseId)
    {
        var result = await _service.GetInventory(productId, warehouseId);
        return Ok(result);
    }

    [HttpPost("Stock-In")]
    public async Task<IActionResult> StockIn(StockDTO dto)
    {
        await _service.StockIn(dto);
        return Ok("Stock Added");
    }

    [HttpPost("Stock-Out")]
    public async Task<IActionResult> StockOut(StockDTO dto)
    {
        await _service.StockOut(dto);
        return Ok("Stock Out ");
    }

    [HttpPost("Transfer")]
    public async Task<IActionResult> TransferStock(TransferStockDTO dto)
    {
        await _service.TransferStock(dto);
        return Ok("Stock Transferred");
    }

}
