using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class LYJD_ZBYJBXX
    {
        public LYJD_ZBYJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 旅游酒店_周边游信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 出游方式
        /// </summary>
        [Property]
        public virtual string CYFS { get; set; }

        /// <summary>
        /// 游玩项目
        /// </summary>
        [Property]
        public virtual string YWXM { get; set; }

        /// <summary>
        /// 适合人群
        /// </summary>
        [Property]
        public virtual string SHRQ { get; set; }

        /// <summary>
        /// 行程天数
        /// </summary>
        [Property]
        public virtual string XCTS_R { get; set; }

        /// <summary>
        /// 门市价
        /// </summary>
        [Property]
        public virtual string MSJ { get; set; }

        /// <summary>
        /// 优惠价_成人
        /// </summary>
        [Property]
        public virtual string YHJ_CR { get; set; }

        /// <summary>
        /// 优惠价_儿童
        /// </summary>
        [Property]
        public virtual string YHJ_ET { get; set; }

        /// <summary>
        /// 服务介绍
        /// </summary>
        [Property]
        public virtual string FWJS { get; set; }

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
