using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class QZZP_QZZPJBXX
    {
        public QZZP_QZZPJBXX()
        {
            QZZP_QZZPJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 求职招聘_全职招聘信息ID
        /// </summary>
        [Id]
        public virtual string QZZP_QZZPJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        [Property]
        public virtual string ZWMC { get; set; }

        /// <summary>
        /// 职位类别
        /// </summary>
        [Property]
        public virtual string ZWLB { get; set; }

        /// <summary>
        /// 招聘人数
        /// </summary>
        [Property]
        public virtual string ZPRS { get; set; }

        /// <summary>
        /// 每月薪资
        /// </summary>
        [Property]
        public virtual string MYXZ { get; set; }

        /// <summary>
        /// 职位福利
        /// </summary>
        [Property]
        public virtual string ZWFL { get; set; }

        /// <summary>
        /// 学历要求
        /// </summary>
        [Property]
        public virtual string XLYQ { get; set; }

        /// <summary>
        /// 工作年限
        /// </summary>
        [Property]
        public virtual string GZNX { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual string BCMS { get; set; }
    }
}
