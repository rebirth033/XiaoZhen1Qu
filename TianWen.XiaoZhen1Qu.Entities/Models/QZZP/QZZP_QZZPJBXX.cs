using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class QZZP_QZZPJBXX
    {
        public QZZP_QZZPJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 求职招聘_全职招聘信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 行业类别
        /// </summary>
        [Property]
        public virtual string HYLB { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        [Property]
        public virtual string ZWMC { get; set; }

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
        public virtual Byte[] BCMS { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Property]
        public virtual string GSMC { get; set; }

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
