using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class HTGL_YHSCXX
    {
        public HTGL_YHSCXX()
        {
            YHSCXXID = Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// 用户收藏信息ID
        /// </summary>
        [Id]
        public virtual string YHSCXXID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Property]
        public virtual string YHID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Property]
        public virtual string TYPE { get; set; }

        /// <summary>
        /// 类型ID
        /// </summary>
        [Property]
        public virtual string TYPEID { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        [Property]
        public virtual string LBID { get; set; }
    }
}
