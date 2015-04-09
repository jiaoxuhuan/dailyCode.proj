using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DailyMvcApplication.Models;
using DailyMvcApplication.DAL;

namespace DailyMvcApplication.BLL
{
    public class UserBLL
    {
        public void AddUser()
        {
            for (int i = 1; i <= 100000; i++)
            {
                string sql = string.Format("insert into UserInfo values ({0},{1})", "'jxh" + i + "'", i);
                CommonDal.ExecuteCommand(sql);
            }
        }
    }
}