using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class ES_SJSM_TSJJBXX
    {
        public ES_SJSM_TSJJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 台式机信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 身份
        /// </summary>
        [Property]
        public virtual string SF { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [Property]
        public virtual string LB { get; set; }

        /// <summary>
        /// 小类
        /// </summary>
        [Property]
        public virtual string XL { get; set; }

        /// <summary>
        /// CPU品牌
        /// </summary>
        [Property]
        public virtual string CPUPP { get; set; }

        /// <summary>
        /// CPU核数
        /// </summary>
        [Property]
        public virtual string CPUHS { get; set; }

        /// <summary>
        /// 内存
        /// </summary>
        [Property]
        public virtual string NC { get; set; }

        /// <summary>
        /// 硬盘
        /// </summary>
        [Property]
        public virtual string YP { get; set; }

        /// <summary>
        /// 屏幕尺寸
        /// </summary>
        [Property]
        public virtual string PMCC { get; set; }

        /// <summary>
        /// 显卡
        /// </summary>
        [Property]
        public virtual string XK { get; set; }

        /// <summary>
        /// 新旧
        /// </summary>
        [Property]
        public virtual string XJ { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [Property]
        public virtual string JG { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual Byte[] BCMS { get; set; }

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
        /// 配送方式
        /// </summary>
        [Property]
        public virtual string PSFS { get; set; }
    }
}
