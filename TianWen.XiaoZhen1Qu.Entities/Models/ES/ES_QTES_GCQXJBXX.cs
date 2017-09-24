using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class ES_QTES_GCQXJBXX
    {
        public ES_QTES_GCQXJBXX()
        {
            ES_QTES_GCQXJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 工程器械信息ID
        /// </summary>
        [Id]
        public virtual string ES_QTES_GCQXJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 供求
        /// </summary>
        [Property]
        public virtual int GQ { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [Property]
        public virtual string LB { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [Property]
        public virtual string JG { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual string BCMS { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        [Property]
        public virtual string PP { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        [Property]
        public virtual string XH { get; set; }

        /// <summary>
        /// 吨位
        /// </summary>
        [Property]
        public virtual string DW { get; set; }

        /// <summary>
        /// 出厂年限
        /// </summary>
        [Property]
        public virtual string CCNX { get; set; }

        /// <summary>
        /// 使用时间
        /// </summary>
        [Property]
        public virtual string SYSJ { get; set; }

        /// <summary>
        /// 所在省
        /// </summary>
        [Property]
        public virtual string SZSHENG { get; set; }

        /// <summary>
        /// 所在市
        /// </summary>
        [Property]
        public virtual string SZSHI { get; set; }

        /// <summary>
        /// 所在乡镇
        /// </summary>
        [Property]
        public virtual string SZXZ { get; set; }
    }
}
