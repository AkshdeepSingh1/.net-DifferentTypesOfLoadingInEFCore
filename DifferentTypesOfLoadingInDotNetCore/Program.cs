using DbLayer.DBContext;
using DbLayer.Repositories;
using DbLayer.Interfaces;
using LogicLayer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();



builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<TryDifferentTypesOfLoadingService>();
//if not using lazy loading
//builder.Services.AddDbContext<ApplicationDbContext>(
//       options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), options => options.MigrationsAssembly("DbLayer")));
// if using lazy loading
builder.Services.AddDbContext<ApplicationDbContext>(
       options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default"), options => options.MigrationsAssembly("DbLayer")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
