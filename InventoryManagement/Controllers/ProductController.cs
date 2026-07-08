using InventoryManagement.DTOs;
using InventoryManagement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService _productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productService.GetAllProducts();
        return Ok(result);
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _productService.GetProductDetail(Id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDTO dto)
    {
        await _productService.CreateProduct(dto);
        return Ok(dto);
    }

    [HttpPut("{Id:guid}")]
    public async Task<IActionResult> Update(Guid Id,UpdateProductDTO dto)
    {
        await _productService.UpdateProduct(Id,dto);
        return Ok("Product Updated Succesfully");
    }

    [HttpDelete("{Id:guid}")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _productService.DeleteProduct(Id);
        return Ok($"Deleted Succesfully with Id {Id}");
    }

}
