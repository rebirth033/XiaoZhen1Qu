using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CL_GCCJBXX
    {
        public CL_GCCJBXX()
        {
            CL_GCCJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 工程车信息ID
        /// </summary>
        [Id]
        public virtual string CL_GCCJBXXID { get; set; }

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
        /// 吨位
        /// </summary>
        [Property]
        public virtual string DW { get; set; }

        /// <summary>
        /// 小时数
        /// </summary>
        [Property]
        public virtual string XSS { get; set; }

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
