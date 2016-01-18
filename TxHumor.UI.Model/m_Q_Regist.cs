using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TxHumor.Common.Attr;

namespace TxHumor.UI.Model
{
    public class m_Q_Regist
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [Attr_RequestParameter("userName",null)]
        public string UserName { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [Attr_RequestParameter("pwd", null)]
        public string Pwd { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [Attr_RequestParameter("email", null)]
        public string Email { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [Attr_RequestParameter("code", null)]
        public string Code { get; set; }
    }
}
