﻿using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CW_HNYCJBXX
    {
        public CW_HNYCJBXX()
        {
            CW_HNYCJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 花鸟鱼虫信息ID
        /// </summary>
        [Id]
        public virtual string CW_HNYCJBXXID { get; set; }

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
        /// 品种
        /// </summary>
        [Property]
        public virtual string PZ { get; set; }

        /// <summary>
        /// 品种
        /// </summary>
        [Property]
        public virtual string XL { get; set; }

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
    }
}
