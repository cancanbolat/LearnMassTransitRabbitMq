using MassTransit;
using System;
using CrossCuttingLayer;
using GreenPipes;

namespace Notification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Notification";
            var bus = Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host(new Uri(RabbitMqConstants.RabbitMqRootUri), h =>
                {
                    h.Username(RabbitMqConstants.UserName);
                    h.Password(RabbitMqConstants.Password);
                });

                config.ReceiveEndpoint("todoQueue", ep =>
                {
                    ep.PrefetchCount = 16;
                    ep.UseMessageRetry(r => r.Interval(2, 100));
                    ep.Consumer<TodoConsumerNotification>();
                });
            });

            bus.StartAsync();
            Console.WriteLine("Listening for Todo registered events.. Press enter to exit");
            Console.ReadLine();
            bus.StopAsync();
        }
    }
}
