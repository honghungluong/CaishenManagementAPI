using CaishenManagementAPI.Datacontext;
using CaishenManagementAPI.Repository;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// dang ky Cors policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNetlify", policy =>
    {
        policy.WithOrigins("https://caishenjewelry.netlify.app")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// use Postgre
builder.Services.AddDbContext<CaishenMngtDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();


var app = builder.Build();

app.UseCors("AllowNetlify");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//using (var scope = app.Services.CreateScope())
//{
//    try
//    {
//        var db = scope.ServiceProvider.GetRequiredService<CaishenMngtDbContext>();
//        db.Database.Migrate();
//        Console.WriteLine("Database migrated successfully.");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Error during database migration:");
//        Console.WriteLine(ex.Message);
//        // log detail
//        Console.WriteLine(ex.StackTrace);
//    }
//}
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables(); //

app.Run();