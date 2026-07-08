using InventoryManagement.Data.Context;
using InventoryManagement.Exceptions;
using InventoryManagement.Mappings;
using InventoryManagement.Model;
using InventoryManagement.Repository.Implementation;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Services.Implementation;
using InventoryManagement.Services.Interface;
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



// unit of work
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

// repositories
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IPurchaseRepository,PurchaseRepository>();

//services 
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IPurchaseService,PurchaseService>();
builder.Services.AddScoped<IInventoryService,InventoryService>();
builder.Services.AddScoped<IWareHouseService,WareHouseService>();
builder.Services.AddScoped<ISupplierService,SupplierService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
