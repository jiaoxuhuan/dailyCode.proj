using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMqSend
{
    /// <summary>
    /// 普通消息，发布到一个queue队列
    /// </summary>
    public class HelloWorld : BasicSend
    {

        public override void Test(string[] args)
        {
            Console.WriteLine("普通的HelloWorld示例:");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);
                    string message = "hello world";
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "hello", null, body);
                    Console.WriteLine("发送消息：" + message);
                }
            }
        }
    }
}
