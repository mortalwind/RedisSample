using Redis.OM;

using RedisSample.API.Abstractions;
using RedisSample.API.Data;

using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(
    
    () => { 
        return ConnectionMultiplexer.Connect("cachename.redis.cache.windows.net,ssl=true,abortConnect=false,password=password"); });
builder.Services.AddSingleton(new RedisConnectionProvider(builder.Configuration.GetConnectionString("RedisConnection")));

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICartsRepository, CartsRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();