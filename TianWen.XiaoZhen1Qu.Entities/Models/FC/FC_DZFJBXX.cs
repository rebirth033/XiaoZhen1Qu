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
        /// 房屋配置
        /// </summary>
        [Property]
        public virtual string FWPZ { get; set; }

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
        public virtual Byte[] BCMS { get; set; }

        /// <summary>
        /// 卧室数
        /// </summary>
        [Property]
        public virtual string WSS { get; set; }

        /// <summary>
        /// 双人床数
        /// </summary>
        [Property]
        public virtual string SRCS { get; set; }

        /// <summary>
        /// 单人床数
        /// </summary>
        [Property]
        public virtual string DRCS { get; set; }

        /// <summary>
        /// 入住时间_时
        /// </summary>
        [Property]
        public virtual string RZSJ_H { get; set; }

        /// <summary>
        /// 入住时间_分
        /// </summary>
        [Property]
        public virtual string RZSJ_M { get; set; }

        /// <summary>
        /// 退房时间_时
        /// </summary>
        [Property]
        public virtual string TFSJ_H { get; set; }

        /// <summary>
        /// 退房时间_分
        /// </summary>
        [Property]
        public virtual string TFSJ_M { get; set; }

        /// <summary>
        /// 押金
        /// </summary>
        [Property]
        public virtual string YJ { get; set; }

        /// <summary>
        /// 定金
        /// </summary>
        [Property]
        public virtual string DJ { get; set; }

        /// <summary>
        /// 有额外费用
        /// </summary>
        [Property]
        public virtual string YEWFY { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [Property]
        public virtual string FKFS { get; set; }

        /// <summary>
        /// 租金
        /// </summary>
        [Property]
        public virtual string ZJ { get; set; }
    }
}
