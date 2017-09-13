using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class ES_JDJJBG_ESJDJBXX
    {
        public ES_JDJJBG_ESJDJBXX()
        {
            ES_JDJJBG_ESJDJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 二手家电信息ID
        /// </summary>
        [Id]
        public virtual string ES_JDJJBG_ESJDJBXXID { get; set; }

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
        /// 小类
        /// </summary>
        [Property]
        public virtual string XL { get; set; }

        /// <summary>
        /// CPU品牌
        /// </summary>
        [Property]
        public virtual string CPUPP { get; set; }

        /// <summary>
        /// CPU核数
        /// </summary>
        [Property]
        public virtual string CPUHS { get; set; }

        /// <summary>
        /// 内存
        /// </summary>
        [Property]
        public virtual string NC { get; set; }

        /// <summary>
        /// 硬盘
        /// </summary>
        [Property]
        public virtual string YP { get; set; }

        /// <summary>
        /// 屏幕尺寸
        /// </summary>
        [Property]
        public virtual string PMCC { get; set; }

        /// <summary>
        /// 显卡
        /// </summary>
        [Property]
        public virtual string XK { get; set; }

        /// <summary>
        /// 新旧
        /// </summary>
        [Property]
        public virtual string XJ { get; set; }

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
    }
}
