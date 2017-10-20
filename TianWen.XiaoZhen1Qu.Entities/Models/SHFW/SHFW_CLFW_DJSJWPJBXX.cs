using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class SHFW_CLFW_DJSJWPJBXX
    {
        public SHFW_CLFW_DJSJWPJBXX()
        {
            SHFW_CLFW_DJSJWPJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 生活服务_车辆服务_代驾/司机外派信息ID
        /// </summary>
        [Id]
        public virtual string SHFW_CLFW_DJSJWPJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [Property]
        public virtual string LB { get; set; }

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
        /// 补充描述
        /// </summary>
        [Property]
        public virtual Byte[] BCMS { get; set; }
    }
}
