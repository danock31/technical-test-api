using Microsoft.EntityFrameworkCore;
using technical_test_api.Infrastructure.Persistence;
using technical_test_api.Infrastructure.Repositories;
using technical_test_api.Domain.Interfaces;
using technical_test_api.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicacionDbContext>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
      policy => policy.WithOrigins("https://orange-bush-0a7574d1e.3.azurestaticapps.net/")
                         .AllowAnyHeader()
                         .AllowAnyMethod());

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
