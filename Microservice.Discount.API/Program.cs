using Microservice.Discount.API;
using Microservice.Discount.API.Features.Discounts;
using Microservice.Discount.API.Options;
using Microservice.Discount.API.Repositories;
using Microservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(DiscountAssembly));
builder.Services.AddSwaggerGen();
builder.Services.AddVersioningExt();

var app = builder.Build();

app.AddDiscountGroupEndpointExt(app.AddVersionSetExt());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwaggerUI();
    app.UseSwagger();
}


app.Run();

