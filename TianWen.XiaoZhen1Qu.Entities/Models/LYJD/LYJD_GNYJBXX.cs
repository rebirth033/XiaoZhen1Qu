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
        /// 出游类别
        /// </summary>
        [Property]
        public virtual string CYLB { get; set; }

        /// <summary>
        /// 出游方式
        /// </summary>
        [Property]
        public virtual string CYFS { get; set; }

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
        public virtual Byte[] XCAP { get; set; }

        /// <summary>
        /// 价格_成人
        /// </summary>
        [Property]
        public virtual string JG_CR { get; set; }

        /// <summary>
        /// 价格_儿童
        /// </summary>
        [Property]
        public virtual string JG_ET { get; set; }

        /// <summary>
        /// 费用包含
        /// </summary>
        [Property]
        public virtual Byte[] FYBH { get; set; }

        /// <summary>
        /// 自费项目
        /// </summary>
        [Property]
        public virtual Byte[] ZFXM { get; set; }

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
