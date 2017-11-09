using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class LYJD_GNYJBXX
    {
        public LYJD_GNYJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 旅游酒店_国内游信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 线路特色
        /// </summary>
        [Property]
        public virtual string XLTS { get; set; }

        /// <summary>
        /// 出游方式
        /// </summary>
        [Property]
        public virtual string CYFS { get; set; }

        /// <summary>
        /// 发团日期
        /// </summary>
        [Property]
        public virtual string FTRQ { get; set; }

        /// <summary>
        /// 往返交通_去
        /// </summary>
        [Property]
        public virtual string WFJT_Q { get; set; }

        /// <summary>
        /// 往返交通_回
        /// </summary>
        [Property]
        public virtual string WFJT_H { get; set; }

        /// <summary>
        /// 行程天数_日
        /// </summary>
        [Property]
        public virtual string XCTS_R { get; set; }

        /// <summary>
        /// 行程天数_晚
        /// </summary>
        [Property]
        public virtual string XCTS_W { get; set; }

        /// <summary>
        /// 行程安排
        /// </summary>
        [Property]
        public virtual string XCAP { get; set; }

        /// <summary>
        /// 预定须知
        /// </summary>
        [Property]
        public virtual string YDXZ { get; set; }

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
        /// 费用包含
        /// </summary>
        [Property]
        public virtual string FYBH { get; set; }

        /// <summary>
        /// 自费项目
        /// </summary>
        [Property]
        public virtual string ZFXM { get; set; }
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
