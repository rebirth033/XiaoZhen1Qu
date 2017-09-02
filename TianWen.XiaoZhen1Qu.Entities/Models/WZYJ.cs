using System;
using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class WZYJ
    {
        public WZYJ()
        {
            WZYJID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 网站意见ID
        /// </summary>
        [Id]
        public virtual string WZYJID { get; set; }

        /// <summary>
        /// 类别
        /// /// </summary>
        [Property]
        public virtual string LB { get; set; }

        /// <summary>
        /// 意见内容
        /// /// </summary>
        [Property]
        public virtual string YJNR { get; set; }

        /// <summary>
        /// 图片
        /// /// </summary>
        [Property]
        public virtual string TP { get; set; }
    }
}
