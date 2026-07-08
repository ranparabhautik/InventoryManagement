using InventoryManagement.DTOs;
using InventoryManagement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace InventoryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WareHouseController(IWareHouseService _service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllWareHouse();
        return Ok(result);
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _service.GetWareHouseById(Id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateWareHouseDTO dto)  
    {
        await _service.CreateWareHouse(dto);
        return Ok("WareHouse Added Succesfully");
    }

    [HttpPut("{Id:guid}")]
    public async Task<IActionResult> Update(Guid Id,UpdateWareHouseDTO dto)
    {
        await _service.UpdateWareHouse(Id,dto);
        return Ok("Updated Succesfully");
    }

    [HttpDelete("{Id:guid}")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _service.DeleteWareHouse(Id);
        return Ok("Deleted Succesfully");
    }
}
