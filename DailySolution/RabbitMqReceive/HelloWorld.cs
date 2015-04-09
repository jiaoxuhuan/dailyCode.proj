using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMqReceive
{
    public class HelloWorld : BasicReceive
    {
        public override void Test(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("hello", false, consumer);
                    Console.WriteLine(" [*] Waiting for messages." +
                                         "To exit press CTRL+C");
                    while (true)
                    {
                        var ea = consumer.Queue.Dequeue();
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("接受消息：" + message);
                    }

                }

            }
        }
    }
}
