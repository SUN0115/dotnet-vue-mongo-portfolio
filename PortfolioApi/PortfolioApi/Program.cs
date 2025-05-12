using MongoDB.Driver;
using PortfolioApi.Configuration;
using PortfolioApi.Repositories;
using PortfolioApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 讀取設定
builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoDB"));

// 注入 MongoClient 為單例
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDB").Get<MongoSettings>();
    return new MongoClient(settings!.ConnectionString);
});

// 加入授權服務（這一行是關鍵）
builder.Services.AddAuthorization();

// 加入控制器服務
builder.Services.AddControllers();

// 依賴注入（根據你自己的服務/資料層命名）
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
