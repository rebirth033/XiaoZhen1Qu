using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class DISTRICT
    {
        public DISTRICT()
        {

        }

        /// <summary>
        /// 行政区编码
        /// </summary>
        [Id]
        public virtual string CODE { get; set; }

        /// <summary>
        /// 行政区名称
        /// </summary>
        [Property]
        public virtual string NAME { get; set; }

        /// <summary>
        /// 父级行政区编码
        /// </summary>
        [Property]
        public virtual string SUPERCODE { get; set; }

        /// <summary>
        /// 父级行政区名称
        /// </summary>
        [Property]
        public virtual string SUPERNAME { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [Property]
        public virtual string GRADE { get; set; }

        /// <summary>
        /// 行政区等级
        /// </summary>
        [Property]
        public virtual int ADLEVEL { get; set; }

        /// <summary>
        /// 所属地域
        /// </summary>
        [Property]
        public virtual string AREA { get; set; }

        /// <summary>
        /// 行政区简称
        /// </summary>
        [Property]
        public virtual string SHORTNAME { get; set; }
    }
}
