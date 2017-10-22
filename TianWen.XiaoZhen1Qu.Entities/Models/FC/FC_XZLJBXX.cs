using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class FC_XZLJBXX
    {
        public FC_XZLJBXX()
        {
            FC_XZLJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 写字楼基本信息ID
        /// </summary>
        [Id]
        public virtual string FC_XZLJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 供求
        /// </summary>
        [Property]
        public virtual string GQ { get; set; }

        /// <summary>
        /// 可注册公司
        /// </summary>
        [Property]
        public virtual string KZCGS { get; set; }

        /// <summary>
        /// 写字楼类型
        /// </summary>
        [Property]
        public virtual string XZLLX { get; set; }

        /// <summary>
        /// 楼盘名称
        /// </summary>
        [Property]
        public virtual string LPMC { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        [Property]
        public virtual string QY { get; set; }

        /// <summary>
        /// 商圈
        /// </summary>
        [Property]
        public virtual string SQ { get; set; }

        /// <summary>
        /// 地段
        /// </summary>
        [Property]
        public virtual string DD { get; set; }

        /// <summary>
        /// 租金
        /// </summary>
        [Property]
        public virtual string ZJ { get; set; }

        /// <summary>
        /// 售价
        /// </summary>
        [Property]
        public virtual string SJ { get; set; }

        /// <summary>
        /// 租金单位
        /// </summary>
        [Property]
        public virtual string ZJDW { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        [Property]
        public virtual string MJ { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual Byte[] BCMS { get; set; }
    }
}
