using CrossCuttingLayer;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Notification
{
    public class TodoConsumerNotification : IConsumer<Todo>
    {
        public async Task Consume(ConsumeContext<Todo> context)
        {
            await Console.Out.WriteLineAsync($"Notification send: todo id: {context.Message.Id}");
        }
    }
}
