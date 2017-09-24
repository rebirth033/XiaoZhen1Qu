using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class PWKQ_YCMPJBXX
    {
        public PWKQ_YCMPJBXX()
        {
            PWKQ_YCMPJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 演出门票信息ID
        /// </summary>
        [Id]
        public virtual string PWKQ_YCMPJBXXID { get; set; }

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
        /// 原价
        /// </summary>
        [Property]
        public virtual string YJ { get; set; }

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
        /// 场馆
        /// </summary>
        [Property]
        public virtual string CG { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Property]
        public virtual DateTime SJ { get; set; }
    }
}
