using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class ZSJM_CYJBXX
    {
        public ZSJM_CYJBXX()
        {
            ZSJM_CYJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 招商加盟_餐饮信息ID
        /// </summary>
        [Id]
        public virtual string ZSJM_CYJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [Property]
        public virtual string LB { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual string BCMS { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        [Property]
        public virtual string QY { get; set; }

        /// <summary>
        /// 地段
        /// </summary>
        [Property]
        public virtual string DD { get; set; }

        /// <summary>
        /// 具体地址
        /// </summary>
        [Property]
        public virtual string JTDZ { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        [Property]
        public virtual string PPMC { get; set; }

        /// <summary>
        /// 品牌历史
        /// </summary>
        [Property]
        public virtual string PPLS { get; set; }

        /// <summary>
        /// 投资金额
        /// </summary>
        [Property]
        public virtual string TZJE { get; set; }

        /// <summary>
        /// 全国分店数
        /// </summary>
        [Property]
        public virtual string QGFDS { get; set; }

        /// <summary>
        /// 单店面积
        /// </summary>
        [Property]
        public virtual string DDMJ { get; set; }

        /// <summary>
        /// 适合人群
        /// </summary>
        [Property]
        public virtual string SHRQ { get; set; }

        /// <summary>
        /// 品牌描述
        /// </summary>
        [Property]
        public virtual string PPMS { get; set; }

        /// <summary>
        /// 招商地区
        /// </summary>
        [Property]
        public virtual string ZSDQ { get; set; }
    }
}
