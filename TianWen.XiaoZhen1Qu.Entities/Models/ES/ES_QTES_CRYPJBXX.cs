﻿using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class ES_QTES_CRYPJBXX
    {
        public ES_QTES_CRYPJBXX()
        {
            ES_QTES_CRYPJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 成人用品信息ID
        /// </summary>
        [Id]
        public virtual string ES_QTES_CRYPJBXXID { get; set; }

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
        /// 小类
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
        public virtual string BCMS { get; set; }

        /// <summary>
        /// 交易区域
        /// </summary>
        [Property]
        public virtual string JYQY { get; set; }

        /// <summary>
        /// 交易地段
        /// </summary>
        [Property]
        public virtual string JYDD { get; set; }
    }
}