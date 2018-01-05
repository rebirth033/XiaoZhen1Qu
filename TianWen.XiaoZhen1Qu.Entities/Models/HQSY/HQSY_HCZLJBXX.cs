using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class HQSY_HCZLJBXX
    {
        public HQSY_HCZLJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 婚庆摄影_婚车租赁ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 套餐出租
        /// </summary>
        [Property]
        public virtual string TCCZ { get; set; }

        /// <summary>
        /// 头车品牌
        /// </summary>
        [Property]
        public virtual string TCPP { get; set; }

        /// <summary>
        /// 头车颜色
        /// </summary>
        [Property]
        public virtual string TCYS { get; set; }

        /// <summary>
        /// 跟车数量
        /// </summary>
        [Property]
        public virtual string GCSL { get; set; }

        /// <summary>
        /// 跟车品牌
        /// </summary>
        [Property]
        public virtual string GCPP { get; set; }

        /// <summary>
        /// 跟车颜色
        /// </summary>
        [Property]
        public virtual string GCYS { get; set; }

        /// <summary>
        /// 免费提供车花 
        /// </summary>
        [Property]
        public virtual string MFTGCH { get; set; }

        /// <summary>
        /// 价内时间 
        /// </summary>
        [Property]
        public virtual string JNSJ { get; set; }

        /// <summary>
        /// 价内公里数
        /// </summary>
        [Property]
        public virtual string JNGLS { get; set; }

        /// <summary>
        /// 价格 
        /// </summary>
        [Property]
        public virtual string JG { get; set; }

        /// <summary>
        /// 服务范围
        /// </summary>
        [Property]
        public virtual string FWQY { get; set; }

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
        /// 补充描述
        /// </summary>
        [Property]
        public virtual Byte[] BCMS { get; set; }
    }
}
