using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class BZZX_WZJY
    {
        public BZZX_WZJY()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 网站意见ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// /// </summary>
        [Property]
        public virtual string YHID { get; set; }

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
    }
}