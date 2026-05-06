using IMS.Queue;
using IMS.Services;

namespace IMS.Workers
{
    public class SignalWorker : BackgroundService
    {
        private readonly SignalQueue _queue;
        private readonly IServiceScopeFactory _scopeFactory;

        public SignalWorker(SignalQueue queue, IServiceScopeFactory scopeFactory)
        {
            _queue = queue;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var signal in _queue.ReadAll())
            {
                using var scope = _scopeFactory.CreateScope();
                var service = scope.ServiceProvider.GetRequiredService<IncidentService>();

                await service.Handle(signal);
            }
        }
    }
}
