﻿using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class JYPX_YYPXJGJBXX
    {
        public JYPX_YYPXJGJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 教育培训_语言培训机构信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 语种
        /// </summary>
        [Property]
        public virtual string YZ { get; set; }

        /// <summary>
        /// 小类
        /// </summary>
        [Property]
        public virtual string XL { get; set; }

        /// <summary>
        /// 专项
        /// </summary>
        [Property]
        public virtual string ZX { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [Property]
        public virtual string JB { get; set; }

        /// <summary>
        /// 服务范围
        /// </summary>
        [Property]
        public virtual string FWFW { get; set; }

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
    }
}
