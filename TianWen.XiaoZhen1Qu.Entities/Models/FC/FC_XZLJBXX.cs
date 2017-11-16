using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class FC_XZLJBXX
    {
        public FC_XZLJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 写字楼基本信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

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
        /// 类型
        /// </summary>
        [Property]
        public virtual string LX { get; set; }

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
        public virtual string DD { get; set; }

        /// <summary>
        /// 具体地址
        /// </summary>
        [Property]
        public virtual string JTDZ { get; set; }

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

        /// <summary>
        /// 物业费
        /// </summary>
        [Property]
        public virtual string WYF { get; set; }

        /// <summary>
        /// 签约年限
        /// </summary>
        [Property]
        public virtual string QYNX { get; set; }

        /// <summary>
        /// 装修格局
        /// </summary>
        [Property]
        public virtual string ZXGJ { get; set; }

        /// <summary>
        /// 押付方式
        /// </summary>
        [Property]
        public virtual string YFFS { get; set; }
    }
}
