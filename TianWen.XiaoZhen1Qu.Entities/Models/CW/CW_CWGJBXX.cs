﻿using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CW_CWGJBXX
    {
        public CW_CWGJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 摩托车信息ID
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
        /// 年龄
        /// </summary>
        [Property]
        public virtual string NL { get; set; }

        /// <summary>
        /// 年龄单位
        /// </summary>
        [Property]
        public virtual string NLDW { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Property]
        public virtual string XB { get; set; }

        /// <summary>
        /// 毛色
        /// </summary>
        [Property]
        public virtual string MS { get; set; }

        /// <summary>
        /// 驱虫情况
        /// </summary>
        [Property]
        public virtual string QCQK { get; set; }

        /// <summary>
        /// 疫苗情况
        /// </summary>
        [Property]
        public virtual string YMQK { get; set; }

        /// <summary>
        /// 疫苗种类
        /// </summary>
        [Property]
        public virtual string YMZL { get; set; }

        /// <summary>
        /// 在售只数
        /// </summary>
        [Property]
        public virtual string ZSZS { get; set; }

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
