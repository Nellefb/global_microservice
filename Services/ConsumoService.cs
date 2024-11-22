using GlobalSolution.Database;
using GlobalSolution.Models;
using MongoDB.Driver;
using StackExchange.Redis;
using System.Text.Json;

namespace GlobalSolution.Services
{
    public class ConsumoService
    {
        private readonly IMongoCollection<Consumo> _consumoCollection;
        private readonly IDatabase _redisDb;
        public ConsumoService(DatabaseConfig dbConfig, IConnectionMultiplexer redis)
        {
            var client = new MongoClient(dbConfig.ConnectionString);
            var database = client.GetDatabase(dbConfig.DatabaseName);
            _consumoCollection = database.GetCollection<Consumo>("consumo");

            _redisDb = redis.GetDatabase();
        }
        public List<Consumo> Get()
        {
            string cacheKey = "consumo:get";

            var cachedData = _redisDb.StringGet(cacheKey);
            if (cachedData.HasValue)
            {
                return JsonSerializer.Deserialize<List<Consumo>>(cachedData);
            }

            var consumos = _consumoCollection.Find(consumo => true).ToList();
            _redisDb.StringSet(cacheKey, JsonSerializer.Serialize(consumos), TimeSpan.FromMinutes(5));
            return consumos;
        }
         public async Task<Consumo> PostConsumo(Consumo consumo)
        {
            _consumoCollection.InsertOne(consumo);
            _redisDb.KeyDelete("consumo:get");
            return consumo;
        }
    }
}
