using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TxHumor.Common.Attr;

namespace TxHumor.UI.Model
{
    public class m_Q_Humor
    {
        /// <summary>
        /// 页码
        /// </summary>
        [Attr_RequestParameter("page", 1)]
        public string Pager { get; set; }

        public int PageIndex
        {
            get
            {
                return Pager == null ? 1 : int.Parse(Pager);
            }
        }
        [Attr_RequestParameter("type", "day")]
        public string Type { get; set; }
    }
}
