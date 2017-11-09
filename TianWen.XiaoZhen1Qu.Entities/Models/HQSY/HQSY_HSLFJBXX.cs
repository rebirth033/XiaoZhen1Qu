using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class HQSY_HSLFJBXX
    {
        public HQSY_HSLFJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 婚庆摄影_婚纱礼服ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        [Property]
        public virtual string YS { get; set; }

        /// <summary>
        /// 风格
        /// </summary>
        [Property]
        public virtual string FG { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Property]
        public virtual string LX { get; set; }

        /// <summary>
        /// 订购周期
        /// </summary>
        [Property]
        public virtual string DGZQ { get; set; }

        /// <summary>
        /// 材质
        /// </summary>
        [Property]
        public virtual string CZ { get; set; }

        /// <summary>
        /// 款式
        /// </summary>
        [Property]
        public virtual string KS { get; set; }

        /// <summary>
        /// 价格 
        /// </summary>
        [Property]
        public virtual string JG { get; set; }

        /// <summary>
        /// 服务区域
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
