using FavoretoAppX.Api.Applicantion.Interfaces;
using FavoretoAppX.Api.Applicantion;
using FavoretoAppX.Domain.Interfaces;
using FavoretoAppX.Domain.Models;
using FavoretoAppX.Infra.Config;
using FavoretoAppX.Infra.Repositories.Repositories;
using FavoretoAppX.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ProductDataBaseSettings>
    (builder.Configuration.GetSection("FavoretoXDataBase"));

builder.Services.AddScoped<IProductApplication, ProductApplication>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
