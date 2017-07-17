using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class PHOTOS
    {
        public PHOTOS()
        {
            PHOTOID = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 照片ID
        /// </summary>
        [Id]
        public virtual string PHOTOID { get; set; }

        /// <summary>
        /// 照片URL
        /// </summary>
        [Property]
        public virtual string PHOTOURL { get; set; }

        /// <summary>
        /// 照片名称
        /// </summary>
        [Property]
        public virtual string PHOTONAME { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }
    }
}
