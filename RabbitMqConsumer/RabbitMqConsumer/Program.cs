using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Diagnostics.Tracing;
using System.Text;

namespace RabbitMqConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //step 1: create Factory connectio
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            //step 3: using factory to create connection
            using var connection = factory.CreateConnection();
            //step 3: using connection to create channel
            using var channel = connection.CreateModel();
            //step 4: using channel to declare queue
            channel.QueueDeclare("demo-queueApp",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            //Step 5: adding Consumer
            var consumer = new EventingBasicConsumer(channel);
            //step 6: recive meassage
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume("demo-queueApp",true,consumer);
            Console.ReadLine();
        }
    }
}
