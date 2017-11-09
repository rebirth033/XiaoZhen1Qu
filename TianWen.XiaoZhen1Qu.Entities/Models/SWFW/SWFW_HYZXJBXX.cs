using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class SWFW_HYZXJBXX
    {
        public SWFW_HYZXJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 商务服务_货运专线信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 运送范围
        /// </summary>
        [Property]
        public virtual string YSFW { get; set; }

        /// <summary>
        /// 出发地区域
        /// </summary>
        [Property]
        public virtual string QY { get; set; }

        /// <summary>
        /// 出发地地段
        /// </summary>
        [Property]
        public virtual string DD { get; set; }

        /// <summary>
        /// 到达地
        /// </summary>
        [Property]
        public virtual string DDD { get; set; }

        /// <summary>
        /// 货运通道
        /// </summary>
        [Property]
        public virtual string HYTD { get; set; }

        /// <summary>
        /// 是否往返
        /// </summary>
        [Property]
        public virtual string SFWF { get; set; }

        /// <summary>
        /// 有无中转
        /// </summary>
        [Property]
        public virtual string YWZZ { get; set; }

        /// <summary>
        /// 班次
        /// </summary>
        [Property]
        public virtual string BC { get; set; }

        /// <summary>
        /// 途中时间
        /// </summary>
        [Property]
        public virtual string TZSJ { get; set; }

        /// <summary>
        /// 组货方式
        /// </summary>
        [Property]
        public virtual string ZHFS { get; set; }

        /// <summary>
        /// 货物种类
        /// </summary>
        [Property]
        public virtual string HWZL { get; set; }

        /// <summary>
        /// 服务延伸
        /// </summary>
        [Property]
        public virtual string FWYS { get; set; }

        /// <summary>
        /// 运输价格
        /// </summary>
        [Property]
        public virtual string YSJG { get; set; }

        /// <summary>
        /// 运输价格单位
        /// </summary>
        [Property]
        public virtual string YSJGDW { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual Byte[] BCMS { get; set; }
    }
}
