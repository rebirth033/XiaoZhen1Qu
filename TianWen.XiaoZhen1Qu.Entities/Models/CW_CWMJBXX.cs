﻿using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CW_CWMJBXX
    {
        public CW_CWMJBXX()
        {
            CW_CWMJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 宠物猫信息ID
        /// </summary>
        [Id]
        public virtual string CW_CWMJBXXID { get; set; }

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
        /// 品种
        /// </summary>
        [Property]
        public virtual string PZ { get; set; }

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
    }
}