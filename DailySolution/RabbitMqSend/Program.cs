using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqSend
{
    class Program
    {
        static void Main(string[] args)
        {
            var send = new Topics();
            send.Test(args);
            Console.ReadLine();
        }
    }
    public class BasicSend
    {
        public virtual void Test(string[] args)
        {
            Console.WriteLine("RabbitMq发送消息示例");
        }
    }
}
