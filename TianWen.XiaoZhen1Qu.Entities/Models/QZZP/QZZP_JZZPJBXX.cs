using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class QZZP_JZZPJBXX
    {
        public QZZP_JZZPJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 求职招聘_兼职招聘信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 兼职类别
        /// </summary>
        [Property]
        public virtual string JZLB { get; set; }

        /// <summary>
        /// 招聘人数
        /// </summary>
        [Property]
        public virtual string ZPRS { get; set; }

        /// <summary>
        /// 兼职时间
        /// </summary>
        [Property]
        public virtual string JZSJ { get; set; }

        /// <summary>
        /// 兼职有效期
        /// </summary>
        [Property]
        public virtual string JZYXQ { get; set; }

        /// <summary>
        /// 短期兼职开始时间
        /// </summary>
        [Property]
        public virtual DateTime DQJZKSSJ { get; set; }

        /// <summary>
        /// 短期兼职结束时间
        /// </summary>
        [Property]
        public virtual DateTime DQJZJSSJ { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual Byte[] BCMS { get; set; }

        /// <summary>
        /// 薪资
        /// </summary>
        [Property]
        public virtual string XZ { get; set; }

        /// <summary>
        /// 薪资单位
        /// </summary>
        [Property]
        public virtual string XZDW { get; set; }

        /// <summary>
        /// 薪资结算
        /// </summary>
        [Property]
        public virtual string XZJS { get; set; }

        /// <summary>
        /// 简历接收邮箱
        /// </summary>
        [Property]
        public virtual string JLJSYX { get; set; }

        /// <summary>
        /// 工作区域
        /// </summary>
        [Property]
        public virtual string QY { get; set; }

        /// <summary>
        /// 工作地段
        /// </summary>
        [Property]
        public virtual string DD { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Property]
        public virtual string XXDZ { get; set; }
    }
}
