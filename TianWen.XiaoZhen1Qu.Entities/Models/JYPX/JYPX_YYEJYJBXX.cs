using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class JYPX_YYEJYJBXX
    {
        public JYPX_YYEJYJBXX()
        {
            JYPX_YYEJYJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 教育培训_婴幼儿教育信息ID
        /// </summary>
        [Id]
        public virtual string JYPX_YYEJYJBXXID { get; set; }

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
        /// 服务类型
        /// </summary>
        [Property]
        public virtual string FWLX { get; set; }

        /// <summary>
        /// 办学性质
        /// </summary>
        [Property]
        public virtual string BXXZ { get; set; }

        /// <summary>
        /// 入托条件
        /// </summary>
        [Property]
        public virtual string RTTJ { get; set; }

        /// <summary>
        /// 营业开始时间_时
        /// </summary>
        [Property]
        public virtual string YYKSSJ_H { get; set; }

        /// <summary>
        /// 营业开始时间_分
        /// </summary>
        [Property]
        public virtual string YYKSSJ_M { get; set; }

        /// <summary>
        /// 营业结束时间_时
        /// </summary>
        [Property]
        public virtual string YYJSSJ_H { get; set; }

        /// <summary>
        /// 营业结束时间_分
        /// </summary>
        [Property]
        public virtual string YYJSSJ_M { get; set; }

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
