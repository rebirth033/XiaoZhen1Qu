using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CL_MTCJBXX
    {
        public CL_MTCJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 摩托车信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 身份
        /// </summary>
        [Property]
        public virtual string SF { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        [Property]
        public virtual string CX { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        [Property]
        public virtual string PP { get; set; }

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

        /// <summary>
        /// 具体地址
        /// </summary>
        [Property]
        public virtual string JTDZ { get; set; }

        /// <summary>
        /// 新旧
        /// </summary>
        [Property]
        public virtual string XJ { get; set; }
    }
}
