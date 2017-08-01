using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class YHXX
    {
        public YHXX()
        {
            YHXXID = Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// 用户消息ID
        /// </summary>
        [Id]
        public virtual string YHXXID { get; set; }

        /// <summary>
        /// 发件人
        /// </summary>
        [Property]
        public virtual string FJR { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [Property]
        public virtual string XXNR { get; set; }

        /// <summary>
        /// 消息时间
        /// </summary>
        [Property]
        public virtual DateTime XXSJ { get; set; }

        /// <summary>
        /// 消息类别
        /// </summary>
        [Property]
        public virtual int XXLB { get; set; }


        /// <summary>
        /// 消息类别
        /// </summary>
        
        public virtual string XXLBMC { get; set; }
    }
}
