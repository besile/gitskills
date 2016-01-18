using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TxHumor.DAL;
using TxHumor.Model;

namespace TxHumor.BLL
{
    public class bll_User
    {
        public static int AddUser(T_User user)
        {
            return dal_User.AddUser(user);
        }
    }
}
