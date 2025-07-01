using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
var app = builder.Build();
app.MapReverseProxy();




if (app.Environment.IsDevelopment())
{
    app.MapGet("/", () => "YARP (Gateway)");
}
else
{
    app.MapGet("/", async context =>
    {
        context.Abort(); 
    });

}



app.Run();