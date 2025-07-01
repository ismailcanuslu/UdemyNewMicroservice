using Microservice.Order.API;
using Microservice.Order.API.Endpoints.Orders;
using Microservice.Order.Application;
using Microservice.Order.Application.Contracts.Repositories;
using Microservice.Order.Application.Contracts.UnitOfWork;
using Microservice.Order.Persistance;
using Microservice.Order.Persistance.Repositories;
using Microservice.Order.Persistance.UnitOfWork;
using Microservice.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped(typeof(IGenericRepository<,>),typeof(GenericRepository<,>));
builder.Services.AddVersioningExt();
builder.Services.AddCommonServiceExt(typeof(OrderApplicationAssembly));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddOpenApi();

var app = builder.Build();
app.AddOrderGroupEndpointExt(app.AddVersionSetExt());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}



app.Run();

