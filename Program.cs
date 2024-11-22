using GlobalSolution.Database;
using GlobalSolution.Repositories;
using GlobalSolution.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var redis = ConnectionMultiplexer.Connect("localhost:6379");
builder.Services.AddSingleton<IConnectionMultiplexer>(redis);    

var dbConfig = new DatabaseConfig("mongodb://localhost:27017", "consumo_energia");
builder.Services.AddSingleton(dbConfig);

builder.Services.AddScoped<ConsumoRepository>();
builder.Services.AddScoped<ConsumoService>();

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
