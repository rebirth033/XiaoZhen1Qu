using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class YHZHXX
    {
        public YHZHXX()
        {
            YHZHXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 房屋出租ID
        /// </summary>
        [Id]
        public virtual string YHZHXXID { get; set; }

        /// <summary>
        /// 现金总金额
        /// </summary>
        [Property]
        public virtual decimal XJZJE { get; set; }

        /// <summary>
        /// 可用总金额
        /// </summary>
        [Property]
        public virtual decimal KYJE { get; set; }

        /// <summary>
        /// 冻结总金额
        /// </summary>
        [Property]
        public virtual decimal DJZJE { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Property]
        public virtual string YHID { get; set; }
    }
}
