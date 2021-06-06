using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json.Serialization;

namespace RabbitMQProducer
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
            //step 5 Create Meassage that u sent
            var message = new { Name = "Producer Man", message = "Hello" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            //step 6 publish message
            channel.BasicPublish("", "demo-queueApp",null,body);
        }
    }
}
