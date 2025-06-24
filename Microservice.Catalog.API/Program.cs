using Microservice.Catalog.API;
using Microservice.Catalog.API.Features.Categories;
using Microservice.Catalog.API.Features.Courses;
using Microservice.Catalog.API.Options;
using Microservice.Shared.Extensions;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));
builder.Services.AddSwaggerGen();
builder.Services.AddVersioningExt();

var app = builder.Build();

app.AddCategoryGroupEndpointExt(app.AddVersionSetExt());
app.AddCourseGroupEndpointExt(app.AddVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

