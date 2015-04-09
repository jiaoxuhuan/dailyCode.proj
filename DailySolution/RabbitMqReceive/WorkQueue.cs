using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqReceive
{
    public class WorkQueue : BasicReceive
    {
        public override void Test(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("task_queue", true, false, false, null);

                   channel.BasicQos(0, 1, false);
                    var consumer = new QueueingBasicConsumer(channel);
                    Console.WriteLine("接收消息:");
                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Recevied:" + message);
                        int dots = message.Split(',').Length - 1;
                        Thread.Sleep(dots * 1000);
                        Console.WriteLine("Done");
                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                }
            }
        }
        //public override void Test()
        //{
        //    var factory = new ConnectionFactory() { HostName = "localhost" };
        //    using (var connection = factory.CreateConnection())
        //    {
        //        using (var channel = connection.CreateModel())
        //        {
        //            channel.QueueDeclare("hello", false, false, false, null);
        //            var consumer = new QueueingBasicConsumer(channel);
        //            channel.BasicConsume("hello", false, consumer);
        //            Console.WriteLine(" [*] Waiting for messages. ");
        //            while (true)
        //            {
        //                var ea =
        //                    (BasicDeliverEventArgs)consumer.Queue.Dequeue();
        //                var body = ea.Body;
        //                var message = Encoding.UTF8.GetString(body);
        //                Console.WriteLine(" [x] Received {0}", message);

        //                int dots = message.Split('.').Length - 1;
        //                Thread.Sleep(dots * 1000);

        //                Console.WriteLine(" [x] Done");
        //            }
        //        }
        //    }
        //}
    }
}
