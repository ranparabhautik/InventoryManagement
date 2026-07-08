using InventoryManagement.DTOs;
using InventoryManagement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService _categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryService.GetAllCategory();
        return Ok(result);
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await _categoryService.GetCategoryById(Id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDTO dto)
    {
        await _categoryService.CreateCategory(dto);
        return Ok("Category Created ");
    }

    [HttpPut("{Id:guid}")]
    public async Task<IActionResult> Update(Guid Id,UpdateCategoriesDTO dto)
    {
        await _categoryService.UpdateCategory(Id, dto);
        return Ok("Category Updated");
    }

    [HttpDelete("{Id:guid}")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _categoryService.DeleteCategory(Id);
        return Ok("Category Deleted");
    }

}
