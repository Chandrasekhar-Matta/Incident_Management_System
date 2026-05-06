using IMS.Models;
using MongoDB.Driver;

namespace IMS.Services
{
    public class MongoService
    {
        private readonly IMongoCollection<Signal> _signals;

        public MongoService(IConfiguration config)
        {
            var client = new MongoClient(config["Mongo:Connection"]);
            var db = client.GetDatabase("IMS");
            _signals = db.GetCollection<Signal>("Signals");
        }

        public async Task SaveSignal(Signal signal)
        {
            try
            {
                await _signals.InsertOneAsync(signal);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mongo Error: " + ex.Message);
            }
        }
    }
}
