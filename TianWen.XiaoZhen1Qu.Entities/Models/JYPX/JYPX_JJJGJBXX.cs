using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class JYPX_JJJGJBXX
    {
        public JYPX_JJJGJBXX()
        {
            JYPX_JJJGJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 教育培训_家教机构信息ID
        /// </summary>
        [Id]
        public virtual string JYPX_JJJGJBXXID { get; set; }

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
        /// 辅导阶段
        /// </summary>
        [Property]
        public virtual string FDJD { get; set; }

        /// <summary>
        /// 辅导科目
        /// </summary>
        [Property]
        public virtual string FDKM { get; set; }

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
