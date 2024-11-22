using GlobalSolution.Database;
using GlobalSolution.Models;
using MongoDB.Driver;

namespace GlobalSolution.Repositories
{
    public class ConsumoRepository
    {
        private readonly IMongoCollection<Consumo> _consumoCollection;

        public ConsumoRepository(DatabaseConfig dbConfig)
        {
            var client = new MongoClient(dbConfig.ConnectionString);
            var database = client.GetDatabase(dbConfig.DatabaseName);
            _consumoCollection = database.GetCollection<Consumo>("consumo");
        }

        public List<Consumo> Get()
        {
            return _consumoCollection.Find(consumo => true).ToList();
        }

        public Consumo Create(Consumo consumo)
        {
            _consumoCollection.InsertOne(consumo);
            return consumo;
        }
    }
}
