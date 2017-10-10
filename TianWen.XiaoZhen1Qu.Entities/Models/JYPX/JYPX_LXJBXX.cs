using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class JYPX_LXJBXX
    {
        public JYPX_LXJBXX()
        {
            JYPX_LXJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 教育培训_留学信息ID
        /// </summary>
        [Id]
        public virtual string JYPX_LXJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [Property]
        public virtual string GJ { get; set; }

        /// <summary>
        /// 申请学历
        /// </summary>
        [Property]
        public virtual string SQXL { get; set; }

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
        public virtual string BCMS { get; set; }
    }
}
