using CaishenManagementAPI.Datacontext;
using CaishenManagementAPI.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = new[]
{
    "https://caishenjewelry.netlify.app",
    "http://www.uptimerobot.com/",
    "http://104.131.107.63",
    "http://122.248.234.23",
    "http://128.140.106.114",
    "http://128.140.41.193",
    "http://128.199.195.156",
    "http://135.181.154.9",
    "http://138.197.150.151",
    "http://139.59.173.249",
    "http://142.132.180.39",
    "http://146.185.143.14",
    "http://157.90.155.240",
    "http://157.90.156.63",
    "http://159.203.30.41",
    "http://159.69.158.189",
    "http://159.89.8.111",
    "http://165.227.83.148",
    "http://167.235.143.113",
    "http://167.99.209.234",
    "http://168.119.123.75",
    "http://168.119.53.160",
    "http://168.119.96.239",
    "http://178.62.52.237",
    "http://18.116.205.62",
    "http://18.180.208.214",
    "http://3.105.133.239",
    "http://3.105.190.221",
    "http://3.12.251.153",
    "http://3.20.63.178",
    "http://3.212.128.62",
    "http://34.198.201.66",
    "http://35.166.228.98",
    "http://35.84.118.171",
    "http://37.27.28.153",
    "http://37.27.29.68",
    "http://37.27.30.213",
    "http://37.27.34.49",
    "http://37.27.82.220",
    "http://37.27.87.149",
    "http://44.227.38.253",
    "http://46.101.250.135",
    "http://49.13.130.29",
    "http://49.13.134.145",
    "http://49.13.164.148",
    "http://49.13.167.123",
    "http://49.13.24.81",
    "http://5.161.61.238",
    "http://5.161.75.7",
    "http://5.78.118.142",
    "http://5.78.87.38",
    "http://52.15.147.27",
    "http://52.22.236.30",
    "http://54.167.223.174",
    "http://54.249.170.27",
    "http://54.64.67.106",
    "http://54.79.28.129",
    "http://65.109.129.165",
    "http://65.109.142.78",
    "http://65.109.8.202",
    "http://78.46.190.63",
    "http://78.46.215.1",
    "http://78.47.173.76",
    "http://78.47.98.55",
    "http://88.99.80.227",
    "http://[2400:6180:0:d0::16:d001]",
    "http://[2406:da14:94d:8601:9d0d:7754:bedf:e4f5]",
    "http://[2406:da14:94d:8601:b325:ff58:2bba:7934]",
    "http://[2406:da14:94d:8601:db4b:c5ac:2cbe:9a79]",
    "http://[2406:da18:caa:9000:44d1:a872:1437:260c]",
    "http://[2406:da1c:9c8:dc02:7ae1:f2ea:ab91:2fde]",
    "http://[2406:da1c:9c8:dc02:7db9:f38b:7b9f:402e]",
    "http://[2406:da1c:9c8:dc02:82b2:f0fd:ee96:0579]",
    "http://[2600:1f14:203:e40d:c86b:1e24:fab4:7d03]",
    "http://[2600:1f14:203:e46c:6c8c:bcb:5245:7a0c]",
    "http://[2600:1f14:203:e48b:5538:77b2:6e13:4f8d]",
    "http://[2600:1f16:775:3a00:37bf:6026:e54a:f03a]",
    "http://[2600:1f16:775:3a00:8c2c:2ba6:778f:5be5]",
    "http://[2600:1f16:775:3a00:ac3:c5eb:7081:942e]",
    "http://[2600:1f16:775:3a00:dbbe:36b0:3c45:da32]",
    "http://[2600:1f18:179:f900:4696:7729:7bb3:f52f]",
    "http://[2600:1f18:179:f900:4b7d:d1cc:2d10:211]",
    "http://[2600:1f18:179:f900:5c68:91b6:5d75:5d7]",
    "http://[2600:1f18:179:f900:71:af9a:ade7:d772]",
    "http://[2604:a880:400:d0::4f:3001]",
    "http://[2604:a880:800:10::4e6:f001]",
    "http://[2604:a880:cad:d0::122:7001]",
    "http://[2604:a880:cad:d0::18:f001]",
    "http://[2a01:4f8:1c1b:4ef4::1]",
    "http://[2a01:4f8:1c1b:5b5a::1]",
    "http://[2a01:4f8:1c1b:7ecc::1]",
    "http://[2a01:4f8:1c1c:11aa::1]",
    "http://[2a01:4f8:1c1c:5353::1]",
    "http://[2a01:4f8:1c1c:7240::1]",
    "http://[2a01:4f8:1c1c:a98a::1]",
    "http://[2a01:4f8:c012:c60e::1]",
    "http://[2a01:4f8:c013:34c0::1]",
    "http://[2a01:4f8:c013:3b0f::1]",
    "http://[2a01:4f8:c013:3c52::1]",
    "http://[2a01:4f8:c013:3c53::1]",
    "http://[2a01:4f8:c013:3c54::1]",
    "http://[2a01:4f8:c013:3c55::1]",
    "http://[2a01:4f8:c013:3c56::1]",
    "http://[2a01:4f8:c013:c18::1]",
    "http://[2a01:4f8:c0c:83fa::1]",
    "http://[2a01:4f8:c17:42e4::1]",
    "http://[2a01:4f8:c2c:9fc6::1]",
    "http://[2a01:4f8:c2c:beae::1]",
    "http://[2a01:4f9:c010:a254::1]",
    "http://[2a01:4f9:c010:b473::1]",
    "http://[2a01:4f9:c010:dc03::1]",
    "http://[2a01:4f9:c010:e70b::1]",
    "http://[2a01:4f9:c012:592a::1]",
    "http://[2a01:4f9:c012:97c5::1]",
    "http://[2a01:4f9:c012:a544::1]",
    "http://[2a01:4f9:c012:a954::1]",
    "http://[2a01:4f9:c012:b246::1]",
    "http://[2a01:4f9:c012:d5a6::1]",
    "http://[2a01:4ff:1f0:9092::1]",
    "http://[2a01:4ff:1f0:e821::1]",
    "http://[2a01:4ff:f0:b2f2::1]",
    "http://[2a01:4ff:f0:e9cf::1]",
    "http://[2a03:b0c0:0:1010::2b:b001]",
    "http://[2a03:b0c0:1:d0::22:5001]",
    "http://[2a03:b0c0:1:d0::e54:a001]",
    "http://[2a03:b0c0:2:d0::fa3:e001]",
    "http://[2a03:b0c0:3:d0::33e:4001]",
    "http://[2a03:b0c0:3:d0::44:f001]"
};

// Add services to the container.
// dang ky Cors policy
builder.Services.AddCors(options =>
{
    //options.AddPolicy("AllowNetlify", policy =>
    //{
    //    policy.WithOrigins("https://caishenjewelry.netlify.app")
    //          .AllowAnyHeader()
    //          .AllowAnyMethod();
    //});
    options.AddPolicy("AllowFromIPs", policy =>
    {
        policy.WithOrigins(allowedOrigins)
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

//app.UseCors("AllowNetlify");
app.UseCors("AllowFromIPs");

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