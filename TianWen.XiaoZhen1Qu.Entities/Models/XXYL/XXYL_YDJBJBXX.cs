﻿using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class XXYL_YDJBJBXX
    {
        public XXYL_YDJBJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 休闲娱乐_夜店酒吧信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [Property]
        public virtual string LB { get; set; }

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
    }
}
