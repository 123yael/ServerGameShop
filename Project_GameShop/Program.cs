using BLL;
using DAL.Actions.classs;
using DAL.Actions.interfaces;
using DAL.Models;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// הוספתי משתנה כדי לגשת לקבועים שנמצאים ב appsettings.json
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("AlowAll", option =>
{
    option.AllowAnyMethod();
    option.AllowAnyHeader();
    option.AllowAnyOrigin();
}));

// הוספת מנהל תלויות
builder.Services.AddDbContext<GameShopDbContext>(y => y.UseSqlServer(configuration["ShopConnectionString"]));

// הוספת שכבות
builder.Services.AddScoped<ICategoriesActions, CategoriesActions>();
builder.Services.AddScoped<IProductsActions, ProductsActions>();
builder.Services.AddScoped<IOrdersActions, OrdersActions>();
builder.Services.AddScoped<IBuyingsDetailsActions, BuyingsDetailsActions>();
builder.Services.AddScoped<IUsersActions, UsersActions>();
builder.Services.AddScoped<IFunctionsBLL, FunctionsBLL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AlowAll");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
