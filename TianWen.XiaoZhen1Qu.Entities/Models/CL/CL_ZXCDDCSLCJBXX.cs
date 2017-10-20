using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CL_ZXCDDCSLCJBXX
    {
        public CL_ZXCDDCSLCJBXX()
        {
            CL_ZXCDDCSLCJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 自行车/电动车/三轮车信息ID
        /// </summary>
        [Id]
        public virtual string CL_ZXCDDCSLCJBXXID { get; set; }

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
        /// 电动车品牌
        /// </summary>
        [Property]
        public virtual string DDCPP { get; set; }

        /// <summary>
        /// 自行车品牌
        /// </summary>
        [Property]
        public virtual string ZXCPP { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        [Property]
        public virtual string CC { get; set; }

        /// <summary>
        /// 电池电压
        /// </summary>
        [Property]
        public virtual string DCDY { get; set; }

        /// <summary>
        /// 电池容量
        /// </summary>
        [Property]
        public virtual string DCRL { get; set; }

        /// <summary>
        /// 使用年限
        /// </summary>
        [Property]
        public virtual string SYNX { get; set; }

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
