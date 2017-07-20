using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class ZDDLXX
    {
        public ZDDLXX()
        {
            ZDDLID = Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Id]
        public virtual string ZDDLID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Property]
        public virtual string YHM { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Property]
        public virtual string SESSIONID { get; set; }
    }
}
