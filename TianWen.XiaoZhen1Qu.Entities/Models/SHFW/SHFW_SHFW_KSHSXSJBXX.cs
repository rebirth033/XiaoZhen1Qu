﻿using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class SHFW_SHFW_KSHSXSJBXX
    {
        public SHFW_SHFW_KSHSXSJBXX()
        {
            SHFW_SHFW_KSHSXSJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 生活服务_开锁/换锁/修锁信息ID
        /// </summary>
        [Id]
        public virtual string SHFW_SHFW_KSHSXSJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

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
