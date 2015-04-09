using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DailyConsoleApplication.multiTask
{
    public class TaskTest
    {
        private static object knife = new object();//临界资源：刀子
        private static object fork = new object();//临界资源：叉子

        //缓冲区,只能容纳一个字符
        private static char buffer;

        //标识量(缓冲区中已使用的空间，初始值为0)
        private static long numberofUsedSpace = 0;

        public void MultiThread()
        {
            //使用入口线程来处理超长时间调用
            Task.Factory.StartNew(() => { Console.WriteLine("sdsd"); });
            List<string> list = new List<string>() { "str1", "str2", "str3" };
            //利用并行来提高多组数据的读取(前提是这些组的数据前后没有依赖关系)
            //MaxDegreeOfParallelism控制最大线程数
            Parallel.ForEach(list,
                             new ParallelOptions() { MaxDegreeOfParallelism = 5 },
                             str => { });
            int a = 0;
            Interlocked.Increment(ref a);
        }

        #region 线程同步类
        public void ThreadSynchronization()
        {
            //1.Interlocked类
            //是通过调用Read()方法，来读取计数器，判断计数器，以此达到线程同步的目的。

            //2.Monitor类
            //通过调用Entry()方法来获取独占锁，当执行完代码，要调用Pulse()方法唤醒睡眠在临界资源上的线程，同时自己调用Wait()方法，睡眠在临界资源，以便下次访问临界区。Monitor与Interlocked的不同点是，当调用Monitor.Entry()方法，未获得独占锁时，线程状态会变为Stopped。而Interlocked正是将线程处于SleepWaitJoin状态。

            //3.Mutex类
            //调用Mutex的WaitOne()方法来获取所属权，获得所属权的线程可以进入临界区，没有所属权的线程在临界区外等待。Mutex对象比Monitor对象消耗资源，但是Mutex对象可以实现跨程序的线程同步。
            //Mutex分为局部互斥、系统互斥。
        }
        #endregion

        #region 死锁
        public void DeadLock()
        {
            Thread girlThread = new Thread(() =>
                {
                    Console.WriteLine("女孩动作开始：");
                    lock (knife)
                    {
                        GetKnife();
                        Thread.Sleep(20);
                        lock (fork)
                        {
                            GetFork();
                            Eat();
                            Console.WriteLine("女孩释放临界资源叉子");
                            Monitor.Pulse(fork);
                        }
                        Console.WriteLine("女孩释放临界资源刀子");
                        Monitor.Pulse(knife);
                    }
                });
            girlThread.Name = "GirlThread";
            Thread boyThread = new Thread(delegate()
                {
                    Console.WriteLine("男孩的动作开始：");
                    lock (knife)//如果 lock (knife)和lock (fork)交换位置则会发生死锁现象
                    {
                        GetKnife();
                        lock (fork)
                        {
                            GetFork();
                            Eat();
                            Console.WriteLine("男孩释放临界资源叉子");
                            Monitor.Pulse(fork);
                        }
                        Console.WriteLine("男孩放下刀子");
                        Monitor.Pulse(knife);
                    }
                });
            boyThread.Name = "BoyThread";
            girlThread.Start();
            boyThread.Start();

        }
        static void GetKnife()
        {
            Console.WriteLine(Thread.CurrentThread.Name + "拿起刀子");
        }
        static void GetFork()
        {
            Console.WriteLine(Thread.CurrentThread.Name + "拿起叉子");
        }
        static void Eat()
        {
            Console.WriteLine(Thread.CurrentThread.Name + "吃东西");
        }

        #endregion

        #region 用委托(Delegate)的BeginInvoke和EndInvoke方法操作线程
        private int NewTask(int ms)
        {
            Console.WriteLine("任务开始：");
            Thread.Sleep(ms);
            Random random = new Random();
            int n = random.Next(10000);
            Console.WriteLine("任务完成");
            return n;
        }

        private delegate int NewTaskDelegate(int ms);
        private void MainTest()
        {
            NewTaskDelegate task = NewTask;
            IAsyncResult result = task.BeginInvoke(2000, null, null);
            int returnMsg = task.EndInvoke(result);
            Console.WriteLine(returnMsg);
        }
        #endregion

    }
}
