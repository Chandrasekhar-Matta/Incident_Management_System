using IMS.Data;
using IMS.Models;
using StackExchange.Redis;

namespace IMS.Services
{
    public class IncidentService
    {
        private readonly MongoService _mongo;
        private readonly AppDbContext _db;

        private static readonly Dictionary<string, DateTime> _debounce = new();

        public IncidentService(MongoService mongo, AppDbContext db)
        {
            _mongo = mongo;
            _db = db;
        }

        public async Task Handle(Signal signal)
        {
            await _mongo.SaveSignal(signal);

            var now = DateTime.UtcNow;

            if (_debounce.ContainsKey(signal.ComponentId) &&
                (now - _debounce[signal.ComponentId]).TotalSeconds < 10)
                return;

            var work = new WorkItem
            {
                ComponentId = signal.ComponentId,
                Severity = signal.ComponentId.Contains("RDBMS") ? "P0" : "P2"
            };

            _db.WorkItems.Add(work);
            await _db.SaveChangesAsync();

            _debounce[signal.ComponentId] = now;
        }

        public async Task Close(int id)
        {
            var work = await _db.WorkItems.FindAsync(id);
            var rca = _db.RCAs.FirstOrDefault(x => x.WorkItemId == id);

            if (rca == null || string.IsNullOrEmpty(rca.RootCause))
                throw new Exception("RCA required");

            work.Status = "CLOSED";
            work.EndTime = DateTime.UtcNow;

            await _db.SaveChangesAsync();
        }
    }
}
