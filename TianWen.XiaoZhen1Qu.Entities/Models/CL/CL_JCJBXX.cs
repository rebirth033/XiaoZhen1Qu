using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CL_JCJBXX
    {
        public CL_JCJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 货车信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        [Property]
        public virtual string PP { get; set; }

        /// <summary>
        /// 车系
        /// </summary>
        [Property]
        public virtual string CX { get; set; }
        /// <summary>
        /// 车辆颜色
        /// </summary>
        [Property]
        public virtual string CLYS { get; set; }

        /// <summary>
        /// 上牌年份
        /// </summary>
        [Property]
        public virtual string SPNF { get; set; }

        /// <summary>
        /// 上牌月份
        /// </summary>
        [Property]
        public virtual string SPYF { get; set; }

        /// <summary>
        /// 是否定期4S店保养
        /// </summary>
        [Property]
        public virtual string SFDQBY { get; set; }

        /// <summary>
        /// 年检到期年份
        /// </summary>
        [Property]
        public virtual string NJDQNF { get; set; }

        /// <summary>
        /// 年检到期月份
        /// </summary>
        [Property]
        public virtual string NJDQYF { get; set; }

        /// <summary>
        /// 交强险到期年份
        /// </summary>
        [Property]
        public virtual string JQXDQNF { get; set; }

        /// <summary>
        /// 交强险到期月份
        /// </summary>
        [Property]
        public virtual string JQXDQYF { get; set; }

        /// <summary>
        /// 商业险到期年份
        /// </summary>
        [Property]
        public virtual string SYXDQNF { get; set; }

        /// <summary>
        /// 商业险到期月份
        /// </summary>
        [Property]
        public virtual string SYXDQYF { get; set; }

        /// <summary>
        /// 行驶里程
        /// </summary>
        [Property]
        public virtual string XSLC { get; set; }

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
        /// 车架号
        /// </summary>
        [Property]
        public virtual string CJH { get; set; }

        /// <summary>
        /// 包含过户费用
        /// </summary>
        [Property]
        public virtual string BHGHFY { get; set; }

        /// <summary>
        /// 支持分期付款
        /// </summary>
        [Property]
        public virtual string ZCFQFK { get; set; }

        /// <summary>
        /// 牌照所在省份
        /// </summary>
        [Property]
        public virtual string PZSZSF { get; set; }

        /// <summary>
        /// 牌照所在城市
        /// </summary>
        [Property]
        public virtual string PZSZCS { get; set; }

        /// <summary>
        /// 车辆是否有抵押
        /// </summary>
        [Property]
        public virtual string SFYDY { get; set; }

        /// <summary>
        /// 车辆加装配置
        /// </summary>
        [Property]
        public virtual string CLJZPZ { get; set; }

        /// <summary>
        /// 过户次数
        /// </summary>
        [Property]
        public virtual string GHCS { get; set; }

        /// <summary>
        /// 看车地址
        /// </summary>
        [Property]
        public virtual string KCDZ { get; set; }
    }
}
