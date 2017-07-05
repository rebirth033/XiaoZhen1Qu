using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class JCXX
    {
        public JCXX()
        {
            JCXXID = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Id]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Property]
        public virtual string YHID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Property]
        public virtual DateTime CJSJ { get; set; }

        /// <summary>
        /// 最新更新时间
        /// </summary>
        [Property]
        public virtual DateTime ZXGXSJ { get; set; }

        /// <summary>
        /// 浏览次数
        /// </summary>
        [Property]
        public virtual int LLCS { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [Property]
        public virtual string LXR { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Property]
        public virtual string LXDH { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        [Property]
        public virtual string LXDZ { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [Property]
        public virtual string QQ { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Property]
        public virtual string BT { get; set; }
    }
}
