using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class HQSY_HLGPJBXX
    {
        public HQSY_HLGPJBXX()
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
        /// 跟拍类型
        /// </summary>
        [Property]
        public virtual string GPLX { get; set; }

        /// <summary>
        /// 摄影师人数
        /// </summary>
        [Property]
        public virtual string SYSRS { get; set; }

        /// <summary>
        /// 跟拍时间
        /// </summary>
        [Property]
        public virtual string GPSJ { get; set; }

        /// <summary>
        /// 摄录器材
        /// </summary>
        [Property]
        public virtual string SLQC { get; set; }

        /// <summary>
        /// 摄录成品
        /// </summary>
        [Property]
        public virtual string SLCP { get; set; }

        /// <summary>
        /// 价格 
        /// </summary>
        [Property]
        public virtual string JG { get; set; }

        /// <summary>
        /// 服务范围
        /// </summary>
        [Property]
        public virtual string FWFW { get; set; }

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
