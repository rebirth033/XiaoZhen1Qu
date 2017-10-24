using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CL_MTCJBXX
    {
        public CL_MTCJBXX()
        {
            CL_MTCJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 摩托车信息ID
        /// </summary>
        [Id]
        public virtual string CL_MTCJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 供求
        /// </summary>
        [Property]
        public virtual string GQ { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [Property]
        public virtual string LB { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        [Property]
        public virtual string PP { get; set; }

        /// <summary>
        /// 行驶里程
        /// </summary>
        [Property]
        public virtual string XSLC { get; set; }

        /// <summary>
        /// 公里数
        /// </summary>
        [Property]
        public virtual string GLS { get; set; }

        /// <summary>
        /// 购车时间
        /// </summary>
        [Property]
        public virtual string GCSJ { get; set; }

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
        public virtual string QY { get; set; }

        /// <summary>
        /// 交易地段
        /// </summary>
        [Property]
        public virtual string DD { get; set; }
    }
}
