using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMqSend
{
    public class Routing : BasicSend
    {
        public override void Test(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //direct类型的消息交换机
                    channel.ExchangeDeclare("direct_logs", "direct");
                    var severity = args.Length > 0 ? args[0] : "info";
                    var message = args.Length > 1 ? string.Join(" ", args.Skip(1).ToArray()) : "hello world";
                    var body = Encoding.UTF8.GetBytes(message);
                    //severity为routing key
                    channel.BasicPublish("direct_logs", severity, null, body);

                    Console.WriteLine(" [x] Sent '{0}':'{1}'", severity, message);
                }
            }
        }
    }
}
