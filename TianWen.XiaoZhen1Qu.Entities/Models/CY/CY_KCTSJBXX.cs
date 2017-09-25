using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CY_KCTSJBXX
    {
        public CY_KCTSJBXX()
        {
            CY_KCTSJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 餐饮_美食信息ID
        /// </summary>
        [Id]
        public virtual string CY_KCTSJBXXID { get; set; }

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
        /// 人均消费
        /// </summary>
        [Property]
        public virtual string RJXF { get; set; }

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

        /// <summary>
        /// 交易具体地址
        /// </summary>
        [Property]
        public virtual string JYJTDZ { get; set; }

        /// <summary>
        /// 推荐菜
        /// </summary>
        [Property]
        public virtual string TJC { get; set; }

        /// <summary>
        /// 交通信息
        /// </summary>
        [Property]
        public virtual string JTXX { get; set; }

        /// <summary>
        /// 服务区域
        /// </summary>
        [Property]
        public virtual string FWQY { get; set; }

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
    }
}
