using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyConsoleApplication.委托
{
    public class DelegateTest
    {
        private string name;
        public string Name { get; set; }

        //无参数无返回值
        public void DisplayToConsole()
        {
            Console.WriteLine(this.Name);
        }
        //带参数带返回值
        public string DisplayToConsole(string namePrefix)
        {
            var newStr = namePrefix + "-" + this.name;
            return newStr;
        }
        public void AllTest()
        {
            this.name = "jiaoxuhuan";
            //内置委托Action的使用
            Action showMethod = DisplayToConsole;
            showMethod();

            //List 中的Foreach方法
            List<string> list = new List<string>() { "str1", "str2", "str3", "str4" };
            list.ForEach(new Action<string>(delegate(string str) { Console.WriteLine(str); }));
            list.ForEach(p => Console.WriteLine(p));

            #region Predicate此委托常用于集合搜索元素，返回bool类型的内置委托
            list.FindAll(p => p.Equals("str1"));
            #endregion

            #region Comparison此委托是比较同一个类型的两个对象的方法，返回int类型的内置委托
            List<Product> list2 = new List<Product>()
                {
                    new Product(){ Name = "name1", Age = 21},
                    new Product(){Name = "name2", Age = 22},
                    new Product(){Name = "name3", Age = 24}
                };
            Comparison<Product> method = Compare;
            list2.Sort(Compare);//直接传入方法名称
            list2.Sort(method);//或者传入委托变量
            list2.ForEach(p => Console.WriteLine("姓名：" + p.Name + "-----年龄：" + p.Age));
            #endregion

            #region lambda表达式代替委托
            list2.Sort((p, a) => p.Age - a.Age);//正序
            list2.Sort((p, a) => a.Age - p.Age);//倒序
            list2.Sort(delegate(Product p1, Product p2)
            {
                return p1.Age - p2.Age;
            });
            #endregion

            //内置委托Func的使用
            Func<string, string> func = DisplayToConsole;
            Console.WriteLine(func("姓名"));
        }
        public int Compare(Product p1, Product p2)
        {
            return p2.Age - p1.Age;
        }
    }
}
