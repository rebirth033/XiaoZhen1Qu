﻿using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class SWFW_PHZPJBXX
    {
        public SWFW_PHZPJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 商务服务_喷绘招牌信息ID
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
        /// 材质
        /// </summary>
        [Property]
        public virtual string CZ { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        [Property]
        public virtual string YT { get; set; }

        /// <summary>
        /// 功能
        /// </summary>
        [Property]
        public virtual string GN { get; set; }

        /// <summary>
        /// 小类
        /// </summary>
        [Property]
        public virtual string XL { get; set; }

        /// <summary>
        /// 工艺
        /// </summary>
        [Property]
        public virtual string GY { get; set; }

        /// <summary>
        /// 是否发光
        /// </summary>
        [Property]
        public virtual string SFFG { get; set; }

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
