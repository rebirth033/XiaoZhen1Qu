﻿using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CL_HCJBXX
    {
        public CL_HCJBXX()
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
        /// 身份
        /// </summary>
        [Property]
        public virtual string SF { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [Property]
        public virtual string LB { get; set; }

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
        /// 行驶里程
        /// </summary>
        [Property]
        public virtual string XSLC { get; set; }

        /// <summary>
        /// 出厂年份
        /// </summary>
        [Property]
        public virtual string CCNF { get; set; }

        /// <summary>
        /// 出厂月份
        /// </summary>
        [Property]
        public virtual string CCYF { get; set; }

        /// <summary>
        /// 额定载重
        /// </summary>
        [Property]
        public virtual string EDZZ { get; set; }

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
