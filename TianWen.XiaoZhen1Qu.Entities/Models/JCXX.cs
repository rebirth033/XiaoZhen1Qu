using System;
using System.Collections.Generic;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class JCXX
    {
        public JCXX()
        {
            JCXXID = Guid.NewGuid().ToString("N");
            PHOTOS = new List<PHOTOS>();
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
        
        /// <summary>
        /// 导航
        /// </summary>
        [Property]
        public virtual string DH { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        [Property]
        public virtual int STATUS { get; set; }

        /// <summary>
        /// 信息类别ID
        /// </summary>
        [Property]
        public virtual int LBID { get; set; }

        public virtual IList<PHOTOS> PHOTOS { get; set; }
    }
}
