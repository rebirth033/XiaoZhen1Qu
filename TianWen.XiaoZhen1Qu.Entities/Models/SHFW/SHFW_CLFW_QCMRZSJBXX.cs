using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class SHFW_CLFW_QCMRZSJBXX
    {
        public SHFW_CLFW_QCMRZSJBXX()
        {
            SHFW_CLFW_QCMRZSJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 生活服务_车辆服务_汽车美容/装饰信息ID
        /// </summary>
        [Id]
        public virtual string SHFW_CLFW_QCMRZSJBXXID { get; set; }

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
        /// 洗车地点
        /// </summary>
        [Property]
        public virtual string XCDD { get; set; }

        /// <summary>
        /// 洗车方式
        /// </summary>
        [Property]
        public virtual string XCFS { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        [Property]
        public virtual string PP { get; set; }

        /// <summary>
        /// 品种
        /// </summary>
        [Property]
        public virtual string PZ { get; set; }

        /// <summary>
        /// 贴膜范围
        /// </summary>
        [Property]
        public virtual string TMFW { get; set; }

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
    }
}
