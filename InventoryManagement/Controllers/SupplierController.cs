using InventoryManagement.DTOs;
using InventoryManagement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace InventoryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController(ISupplierService _supplierService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _supplierService.GetAllSupplier();
        return Ok(result);
    }
    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _supplierService.GetSupplierById(Id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSupplierDTO dto)
    {
        await _supplierService.CreateSupplier(dto);
        return Ok("Supplier Added");
    }

    [HttpPut("{Id:guid}")]
    public async Task<IActionResult> Update(Guid Id,UpdateSupplierDTO dto)
    {
        await _supplierService.UpdateSupplier(Id, dto);
        return Ok("Supplier updated");
    }

    [HttpDelete("{Id:guid}")]
    public async Task<IActionResult> Delete(Guid Id )
    {
        await _supplierService.DeleteSupplier(Id);
        return Ok("Supplier Deleted");
    }


}
