using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqReceive
{
    class Program
    {
        /// <summary>
        /// 可以使用csc 编译文件
        ///csc /r:"C:\DailySolution\Rab
        ///bitMqReceive\Lib\RabbitMQ.Client.dll" /out:Receive.exe C:\DailySolution\RabbitMq
        ///Receive\Program.cs C:\DailySolution\RabbitMqReceive\WorkQueue.cs
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var receive = new Topics();
            receive.Test(args);
        }
    }
    public class BasicReceive
    {
        public virtual void Test(string[] args)
        {

        }
    }

}
