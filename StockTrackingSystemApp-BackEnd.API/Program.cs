using Microsoft.EntityFrameworkCore;
using StockTrackingSystemApp_BackEnd.Infrastructure.Data;
using StockTrackingSystemApp_BackEnd.Application.Interfaces;
using StockTrackingSystemApp_BackEnd.Application.Services;
using StockTrackingSystemApp_BackEnd.Application.Interfaces.Repositories;
using StockTrackingSystemApp_BackEnd.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Connection string'i appsettings.json'dan alıyoruz
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// EF Core DbContext'ini ekleyin
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Application servislerini DI container'a ekleyin
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IDepotService, DepotService>();

// Repository implementasyonlarını ekleyin (Repository arayüzleri Application katmanında tanımlandıysa)
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDepotRepository, DepotRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();