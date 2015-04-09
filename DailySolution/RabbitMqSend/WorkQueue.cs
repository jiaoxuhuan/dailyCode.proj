using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMqSend
{
    /// <summary>
    /// 工作队列消息,发布到一个queue队列
    /// </summary>
    public class WorkQueue : BasicSend
    {
        public override void Test(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("task_queue", true, false, false, null);
                    var message = GetMessage(args);
                    var body = Encoding.UTF8.GetBytes(message);
                    var properties = channel.CreateBasicProperties();
                    properties.SetPersistent(true);//持久化

                    channel.BasicPublish("", "task_queue", properties, body);//发送消息
                    Console.WriteLine("发送消息：" + message);
                }
            }
        }
        //public override void Test(string[] args)
        //{
        //    var factory = new ConnectionFactory() { HostName = "localhost" };
        //    using (var connection = factory.CreateConnection())
        //    {
        //        using (var channel = connection.CreateModel())
        //        {
        //            channel.QueueDeclare("hello", false, false, false, null);
        //            var message = GetMessage(args);
        //            var body = Encoding.UTF8.GetBytes(message);
        //            channel.BasicPublish("", "hello", body);
        //        }
        //    }
        //}
        public static string GetMessage(string[] args)
        {
            return args.Length > 0 ? string.Join(",", args) : "hello world";
        }
    }
}
