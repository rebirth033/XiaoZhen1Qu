﻿using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class SHFW_WXFW_SJSMWXJBXX
    {
        public SHFW_WXFW_SJSMWXJBXX()
        {
            SHFW_WXFW_SJSMWXJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 生活服务_手机数码维修信息ID
        /// </summary>
        [Id]
        public virtual string SHFW_WXFW_SJSMWXJBXXID { get; set; }

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
        /// 小类
        /// </summary>
        [Property]
        public virtual string XL { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual string BCMS { get; set; }

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
        /// 服务区域
        /// </summary>
        [Property]
        public virtual string FWQY { get; set; }
    }
}