using MongoDB.Driver;
using PortfolioApi.Configuration;
using PortfolioApi.Repositories;
using PortfolioApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Ū���]�w
builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoDB"));

// �`�J MongoClient �����
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDB").Get<MongoSettings>();
    return new MongoClient(settings!.ConnectionString);
});

// �[�J���v�A�ȡ]�o�@��O����^
builder.Services.AddAuthorization();

// �[�J����A��
builder.Services.AddControllers();

// �̿�`�J�]�ھڧA�ۤv���A��/��Ƽh�R�W�^
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
