using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class FC_SPJBXX
    {
        public FC_SPJBXX()
        {
            FC_SPJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 商铺基本信息ID
        /// </summary>
        [Id]
        public virtual string FC_SPJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [Property]
        public virtual int FL { get; set; }

        /// <summary>
        /// 供求
        /// </summary>
        [Property]
        public virtual int GQ { get; set; }

        /// <summary>
        /// 商铺类型
        /// </summary>
        [Property]
        public virtual string SPLX { get; set; }

        /// <summary>
        /// 历史经营
        /// </summary>
        [Property]
        public virtual string LSJY { get; set; }

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
        public virtual int MJ { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual string BCMS { get; set; }
    }
}
