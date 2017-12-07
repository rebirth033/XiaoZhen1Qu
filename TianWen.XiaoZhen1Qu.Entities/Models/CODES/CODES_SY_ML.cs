using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models.CODES
{
    public class CODES_SY_ML
    {
        /// <summary>
        /// ID
        /// </summary>
        [Id]
        public virtual int ID { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        [Property]
        public virtual int LBID { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        [Property]
        public virtual string LBNAME { get; set; }

        /// <summary>
        /// 类别顺序
        /// </summary>
        [Property]
        public virtual int LBORDER { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        [Property]
        public virtual int PARENTID { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Property]
        public virtual string TYPE { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        [Property]
        public virtual string TYPENAME { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        [Property]
        public virtual string CONDITION { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        [Property]
        public virtual string ISHOT { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        [Property]
        public virtual string TYPESHOWNAME { get; set; }
        
        /// <summary>
        /// 类别URL
        /// </summary>
        [Property]
        public virtual string LBURL { get; set; }
    }
}
