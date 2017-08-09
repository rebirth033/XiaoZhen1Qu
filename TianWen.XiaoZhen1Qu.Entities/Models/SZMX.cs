using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;
using Remotion.Linq.Clauses.ResultOperators;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class SZMX
    {
        public SZMX()
        {
            SZMXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 收支说明ID
        /// </summary>
        [Id]
        public virtual string SZMXID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Property]
        public virtual DateTime CJSJ { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Property]
        public virtual string LX { get; set; }

        /// <summary>
        /// 交易说明
        /// </summary>
        [Property]
        public virtual string JYSM { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Property]
        public virtual decimal JE { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Property]
        public virtual string JELX { get; set; }
    }
}
