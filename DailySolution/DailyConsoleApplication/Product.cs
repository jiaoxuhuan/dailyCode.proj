using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyConsoleApplication
{
    public class Product
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
    }
    public static class Extend
    {
        //扩展方法
        public static IQueryable<Product> WhereDeleted(this IQueryable<Product> list)
        {
            return list.Where(a => !a.IsDeleted);
        }
    }

}
