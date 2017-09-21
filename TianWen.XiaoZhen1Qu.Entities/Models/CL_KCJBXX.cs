using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CL_KCJBXX
    {
        public CL_KCJBXX()
        {
            CL_KCJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 货车信息ID
        /// </summary>
        [Id]
        public virtual string CL_KCJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 供求
        /// </summary>
        [Property]
        public virtual int GQ { get; set; }

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
        /// 出厂年限
        /// </summary>
        [Property]
        public virtual string CCNX { get; set; }

        /// <summary>
        /// 出厂月份
        /// </summary>
        [Property]
        public virtual string CCYF { get; set; }

        /// <summary>
        /// 额定载重
        /// </summary>
        [Property]
        public virtual string EDZZ { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [Property]
        public virtual string JG { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual string BCMS { get; set; }

        /// <summary>
        /// 交易区域
        /// </summary>
        [Property]
        public virtual string JYQY { get; set; }

        /// <summary>
        /// 交易地段
        /// </summary>
        [Property]
        public virtual string JYDD { get; set; }
    }
}
