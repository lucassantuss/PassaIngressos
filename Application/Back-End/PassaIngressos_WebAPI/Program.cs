using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PassaIngressos_WebAPI.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Passa Ingressos", Version = "v1" });
});

builder.Services.AddDbContext<DbPassaIngressos>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("db_PassaIngressos")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "API V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();