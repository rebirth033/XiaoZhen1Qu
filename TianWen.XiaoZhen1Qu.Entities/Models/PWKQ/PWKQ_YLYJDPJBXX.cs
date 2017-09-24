using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class PWKQ_YLYJDPJBXX
    {
        public PWKQ_YLYJDPJBXX()
        {
            PWKQ_YLYJDPJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 游乐园景点票信息ID
        /// </summary>
        [Id]
        public virtual string PWKQ_YLYJDPJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 供求
        /// </summary>
        [Property]
        public virtual int GQ { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [Property]
        public virtual string LB { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [Property]
        public virtual string JG { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual string BCMS { get; set; }

        /// <summary>
        /// 交易区域
        /// </summary>
        [Property]
        public virtual string JYQY { get; set; }

        /// <summary>
        /// 交易地段
        /// </summary>
        [Property]
        public virtual string JYDD { get; set; }

        /// <summary>
        /// 有效期至
        /// </summary>
        [Property]
        public virtual DateTime YXQZ { get; set; }
    }
}
