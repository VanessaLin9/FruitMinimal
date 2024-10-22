global using ILogger = Serilog.ILogger;
using FruitMinimal.EndPoints;
using FruitMinimal.StartUp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.RegisterService();

builder.WebHost.UseKestrel(option =>
{
    option.ListenAnyIP(14000, o => o.Protocols = HttpProtocols.Http1);
    option.AllowSynchronousIO = true;
});

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.RequestProperties
                            | HttpLoggingFields.RequestQuery
                            | HttpLoggingFields.RequestBody
                            | HttpLoggingFields.ResponseStatusCode
                            | HttpLoggingFields.ResponseBody
                            | HttpLoggingFields.Duration;

    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});

var app = builder.Build();
app.UseHttpLogging();
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseCors(x => x.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("Authentication"));
}
app.MapHealthCheckApi();
app.MapFruitApi();
app.UseSwagger(c => { c.RouteTemplate = "/mgmt/swagger/{documentName}/swagger.json"; });
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/mgmt/swagger/v1/swagger.json", "API Document V1");
    c.RoutePrefix = "mgmt/swagger";
});
app.Run();
