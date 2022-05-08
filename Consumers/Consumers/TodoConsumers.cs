using CrossCuttingLayer;
using MassTransit;
using System.Threading.Tasks;

namespace Consumers.Consumers
{
    public class TodoConsumers : IConsumer<Todo>
    {
        public async Task Consume(ConsumeContext<Todo> context)
        {
            var data = context.Message;
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
        }
    }
}
