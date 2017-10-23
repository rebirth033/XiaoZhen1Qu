using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class PWKQ_XFKGWQJBXX
    {
        public PWKQ_XFKGWQJBXX()
        {
            PWKQ_XFKGWQJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 消费卡购物卡信息ID
        /// </summary>
        [Id]
        public virtual string PWKQ_XFKGWQJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 供求
        /// </summary>
        [Property]
        public virtual string GQ { get; set; }

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
        public virtual Byte[] BCMS { get; set; }

        /// <summary>
        /// 交易区域
        /// </summary>
        [Property]
        public virtual string QY { get; set; }

        /// <summary>
        /// 交易地段
        /// </summary>
        [Property]
        public virtual string DD { get; set; }

        /// <summary>
        /// 有效期至
        /// </summary>
        [Property]
        public virtual DateTime YXQZ { get; set; }
    }
}
