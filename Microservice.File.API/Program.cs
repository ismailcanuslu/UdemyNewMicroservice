using Microservice.File.API;
using Microservice.File.API.Features.File;
using Microservice.Shared.Extensions;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCommonServiceExt(typeof(FileAssembly));
builder.Services.AddSwaggerGen();
builder.Services.AddVersioningExt();
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider
    (Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

var app = builder.Build();

app.UseStaticFiles();

app.AddFileEndpointGroupExt(app.AddVersionSetExt());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

