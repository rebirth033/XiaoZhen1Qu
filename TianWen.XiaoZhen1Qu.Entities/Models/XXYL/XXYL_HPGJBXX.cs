using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class XXYL_HPGJBXX
    {
        public XXYL_HPGJBXX()
        {
            XXYL_HPGJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 休闲娱乐_户外信息ID
        /// </summary>
        [Id]
        public virtual string XXYL_HPGJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 室内设备
        /// </summary>
        [Property]
        public virtual string SNSB { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual string BCMS { get; set; }

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
        /// 可容纳人数
        /// </summary>
        [Property]
        public virtual string KRNRS { get; set; }

        /// <summary>
        /// 场地面积
        /// </summary>
        [Property]
        public virtual string CDMJ { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [Property]
        public virtual string JG { get; set; }
    }
}
