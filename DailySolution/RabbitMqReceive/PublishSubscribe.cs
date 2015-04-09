using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqReceive
{
    public class PublishSubscribe : BasicReceive
    {
        public override void Test(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("logs", "fanout");

                    var queueName = channel.QueueDeclare().QueueName;
                    //The meaning of a binding key depends on the exchange type. The fanout exchanges,
                    //which we used previously, simply ignored its value
                    channel.QueueBind(queueName, "logs", "");
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queueName, true, consumer);

                    Console.WriteLine("接收消息：");
                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Recevied:" + message);
                    }
                }
            }
        }
    }
}
