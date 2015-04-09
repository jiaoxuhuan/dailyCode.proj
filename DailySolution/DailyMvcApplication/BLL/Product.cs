using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailyMvcApplication.BLL
{
    public class Product
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public void Validate1()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                throw new Exception("please enter a name for the product");
            }
            if (string.IsNullOrEmpty(this.Description))
            {
                throw new Exception("product description is required");
            }
        }
        public void Validate2()
        {
            Require(this, x => x.Name, "please enter a name for the product");
        }

        public static void Require<TA>(TA tSource, Func<TA, string> func, string exptionMsg)
        {
            if (string.IsNullOrEmpty(func(tSource)))
            {
                throw new Exception(exptionMsg);
            }
            List<int> list = new List<int>();
            list.Select(x => x);
            list.ForEach(delegate(int a){Console.WriteLine(a);});
        }
    }
}