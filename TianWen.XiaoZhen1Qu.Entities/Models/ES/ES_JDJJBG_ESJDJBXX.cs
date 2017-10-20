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
        /// 电视屏幕尺寸
        /// </summary>
        [Property]
        public virtual string DSPMCC { get; set; }

        /// <summary>
        /// 电视品牌
        /// </summary>
        [Property]
        public virtual string DSPP { get; set; }

        /// <summary>
        /// 洗衣机品牌
        /// </summary>
        [Property]
        public virtual string XYJPP { get; set; }

        /// <summary>
        /// 空调品牌
        /// </summary>
        [Property]
        public virtual string KTPP { get; set; }

        /// <summary>
        /// 空调变频定速
        /// </summary>
        [Property]
        public virtual string KTBPDS { get; set; }

        /// <summary>
        /// 空调功率
        /// </summary>
        [Property]
        public virtual string KTGL { get; set; }

        /// <summary>
        /// 冰箱品牌
        /// </summary>
        [Property]
        public virtual string BXPP { get; set; }

        /// <summary>
        /// 冰柜品牌
        /// </summary>
        [Property]
        public virtual string BGPP { get; set; }

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
    }
}
