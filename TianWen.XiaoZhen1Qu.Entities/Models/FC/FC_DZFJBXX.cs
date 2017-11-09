using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class FC_DZFJBXX
    {
        public FC_DZFJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 短租房基本信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 房屋类型
        /// </summary>
        [Property]
        public virtual string FWLX { get; set; }

        /// <summary>
        /// 最短租期
        /// </summary>
        [Property]
        public virtual string ZDZQ { get; set; }

        /// <summary>
        /// 租金
        /// </summary>
        [Property]
        public virtual string ZJ { get; set; }

        /// <summary>
        /// 宜租人数
        /// </summary>
        [Property]
        public virtual string YZRS { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        [Property]
        public virtual string MJ { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Property]
        public virtual string DZ { get; set; }

        /// <summary>
        /// 交易规则
        /// </summary>
        [Property]
        public virtual string JYGZ { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual Byte[] BCMS { get; set; }
    }
}
