using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class FC_SPJBXX
    {
        public FC_SPJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [Property]
        public virtual string FL { get; set; }

        /// <summary>
        /// 供求
        /// </summary>
        [Property]
        public virtual string GQ { get; set; }

        /// <summary>
        /// 商铺类型
        /// </summary>
        [Property]
        public virtual string SPLX { get; set; }

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
        /// 面宽
        /// </summary>
        [Property]
        public virtual string MK { get; set; }

        /// <summary>
        /// 进深
        /// </summary>
        [Property]
        public virtual string JS { get; set; }

        /// <summary>
        /// 层高
        /// </summary>
        [Property]
        public virtual string CG { get; set; }

        /// <summary>
        /// 层
        /// </summary>
        [Property]
        public virtual string C { get; set; }

        /// <summary>
        /// 共几层
        /// </summary>
        [Property]
        public virtual string GJC { get; set; }

        /// <summary>
        /// 经营行业
        /// </summary>
        [Property]
        public virtual string JYHY { get; set; }

        /// <summary>
        /// 经营状态
        /// </summary>
        [Property]
        public virtual string JYZT { get; set; }

        /// <summary>
        /// 商铺配套
        /// </summary>
        [Property]
        public virtual string PT { get; set; }

        /// <summary>
        /// 电费
        /// </summary>
        [Property]
        public virtual string DF { get; set; }

        /// <summary>
        /// 水费
        /// </summary>
        [Property]
        public virtual string SF { get; set; }

        /// <summary>
        /// 物业费
        /// </summary>
        [Property]
        public virtual string WYF { get; set; }

        /// <summary>
        /// 押付方式
        /// </summary>
        [Property]
        public virtual string YFFS { get; set; }

        /// <summary>
        /// 起租期
        /// </summary>
        [Property]
        public virtual string QZQ { get; set; }

        /// <summary>
        /// 免租期
        /// </summary>
        [Property]
        public virtual string MZQ { get; set; }

        /// <summary>
        /// 是否临街
        /// </summary>
        [Property]
        public virtual string SFLJ { get; set; }
    }
}
