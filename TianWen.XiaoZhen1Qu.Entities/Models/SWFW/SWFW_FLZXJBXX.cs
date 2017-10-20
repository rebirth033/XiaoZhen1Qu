using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class SWFW_FLZXJBXX
    {
        public SWFW_FLZXJBXX()
        {
            SWFW_FLZXJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 商务服务_法律咨询信息ID
        /// </summary>
        [Id]
        public virtual string SWFW_FLZXJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [Property]
        public virtual string LY { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [Property]
        public virtual string LB { get; set; }

        /// <summary>
        /// 执业证号
        /// </summary>
        [Property]
        public virtual string ZYZH { get; set; }

        /// <summary>
        /// 执业机构
        /// </summary>
        [Property]
        public virtual string ZYJG { get; set; }

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
