using System;
using StackExchange.Redis;
using System.Threading;

namespace DailyConsoleApplication.RedisTest
{
    public class Redis
    {
        public void Test()
        {
            var redis = ConnectionMultiplexer.Connect("127.0.0.1");
            var db = redis.GetDatabase();

            TimeSpan ts = DateTime.Now.AddSeconds(3600) - DateTime.Now;
            db.StringSet("key", "jiaoxuhuan");
            Thread.Sleep(new TimeSpan(3600));
            var val = db.StringGet("key");
            Console.WriteLine("取值：" + val);
        }
    }
}
