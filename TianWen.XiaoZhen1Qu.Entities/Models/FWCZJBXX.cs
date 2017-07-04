﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class FWCZJBXX
    {
        public FWCZJBXX()
        {
            FWCZID = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 房屋出租ID
        /// </summary>
        [Id]
        public virtual string FWCZID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 出租方式
        /// </summary>
        [Property]
        public virtual int CZFS { get; set; }

        /// <summary>
        /// 小区名称
        /// </summary>
        [Property]
        public virtual string XQMC { get; set; }

        /// <summary>
        /// 室
        /// </summary>
        [Property]
        public virtual int S { get; set; }

        /// <summary>
        /// 厅
        /// </summary>
        [Property]
        public virtual int T { get; set; }

        /// <summary>
        /// 卫
        /// </summary>
        [Property]
        public virtual int W { get; set; }

        /// <summary>
        /// 平方米
        /// </summary>
        [Property]
        public virtual int PFM { get; set; }
        /// <summary>
        /// 朝向
        /// </summary>
        [Property]
        public virtual string CX { get; set; }
        /// <summary>
        /// 装修情况
        /// </summary>
        [Property]
        public virtual string ZXQK { get; set; }
        /// <summary>
        /// 住宅类型
        /// </summary>
        [Property]
        public virtual string ZZLX { get; set; }
        /// <summary>
        /// 层
        /// </summary>
        [Property]
        public virtual int C { get; set; }
        /// <summary>
        /// 共几层
        /// </summary>
        [Property]
        public virtual int GJC { get; set; }
        /// <summary>
        /// 租金
        /// </summary>
        [Property]
        public virtual int ZJ { get; set; }
        /// <summary>
        /// 押付方式
        /// </summary>
        [Property]
        public virtual string YFFS { get; set; }
        /// <summary>
        /// 租金已包含费用
        /// </summary>
        [Property]
        public virtual string ZJYBHFY { get; set; }
        /// <summary>
        /// 房屋配置
        /// </summary>
        [Property]
        public virtual string FWPZ { get; set; }
        /// <summary>
        /// 房屋亮点
        /// </summary>
        [Property]
        public virtual string FWLD { get; set; }
        /// <summary>
        /// 出租要求
        /// </summary>
        [Property]
        public virtual string CZYQ { get; set; }
        /// <summary>
        /// 房源描述
        /// </summary>
        [Property]
        public virtual string FYMS { get; set; }
        /// <summary>
        /// 可入住时间
        /// </summary>
        [Property]
        public virtual DateTime KRZSJ { get; set; }
    }
}
