using InventoryManagement.Data.Context;
using InventoryManagement.Mappings;
using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(option => { option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")); });

builder.Services.AddAutoMapper(cfg=> cfg.AddProfile<CategoryMapping>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ProductMapping>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<SupplierMapping>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<InventoryProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<WareHouseMapping>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<PurchaseOrderMapping>());

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
