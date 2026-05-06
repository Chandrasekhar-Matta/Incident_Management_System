using IMS.Models;
using System.Threading.Channels;


namespace IMS.Queue
{
    public class SignalQueue
    {
        private readonly Channel<Signal> _queue = Channel.CreateUnbounded<Signal>();

        public object signal { get; internal set; }

        public async Task Enqueue(Signal signal)
        {
            await _queue.Writer.WriteAsync(signal);
        }

        public IAsyncEnumerable<Signal> ReadAll()
        {
            return _queue.Reader.ReadAllAsync();
        }
    }
}
