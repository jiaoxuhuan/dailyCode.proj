﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMqSend
{
    /// <summary>
    /// 发布/订阅消息,发布到一个Exchange
    /// </summary>
    public class PublishSubscribe : BasicSend
    {
        public override void Test(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("logs", "fanout");

                    var message = GetMessage(args);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("logs", "", null, body);
                    Console.WriteLine("发送消息：" + message);
                }
            }
        }

        private string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "info: Hello World!");
        }
    }
}
