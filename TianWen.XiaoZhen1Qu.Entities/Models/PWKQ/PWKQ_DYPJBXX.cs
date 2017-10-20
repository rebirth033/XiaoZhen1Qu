using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class PWKQ_DYPJBXX
    {
        public PWKQ_DYPJBXX()
        {
            PWKQ_DYPJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 电影票信息ID
        /// </summary>
        [Id]
        public virtual string PWKQ_DYPJBXXID { get; set; }

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
        public virtual int LB { get; set; }

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
        public virtual string JYQY { get; set; }

        /// <summary>
        /// 交易地段
        /// </summary>
        [Property]
        public virtual string JYDD { get; set; }

        /// <summary>
        /// 影院
        /// </summary>
        [Property]
        public virtual string YY { get; set; }

        /// <summary>
        /// 有效期至
        /// </summary>
        [Property]
        public virtual DateTime YXQZ { get; set; }
    }
}
