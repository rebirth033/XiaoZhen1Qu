using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class FC_ESFJBXX
    {
        public FC_ESFJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 房屋出租ID
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
        /// 小区名称
        /// </summary>
        [Property]
        public virtual string XQMC { get; set; }

        /// <summary>
        /// 室
        /// </summary>
        [Property]
        public virtual string S { get; set; }

        /// <summary>
        /// 厅
        /// </summary>
        [Property]
        public virtual string T { get; set; }

        /// <summary>
        /// 卫
        /// </summary>
        [Property]
        public virtual string W { get; set; }

        /// <summary>
        /// 平方米
        /// </summary>
        [Property]
        public virtual string PFM { get; set; }

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
        public virtual string C { get; set; }

        /// <summary>
        /// 共几层
        /// </summary>
        [Property]
        public virtual string GJC { get; set; }

        /// <summary>
        /// 售价
        /// </summary>
        [Property]
        public virtual decimal SJ { get; set; }

        /// <summary>
        /// 房屋亮点
        /// </summary>
        [Property]
        public virtual string FWLD { get; set; }

        /// <summary>
        /// 房源描述
        /// </summary>
        [Property]
        public virtual byte[] BCMS { get; set; }

        /// <summary>
        /// 可入住时间
        /// </summary>
        [Property]
        public virtual DateTime KRZSJ { get; set; }

        /// <summary>
        /// 产权年限
        /// </summary>
        [Property]
        public virtual string CQNX { get; set; }

        /// <summary>
        /// 产权类型
        /// </summary>
        [Property]
        public virtual string CQLX { get; set; }
    }
}
