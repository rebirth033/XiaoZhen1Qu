﻿using System.Collections.Generic;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CODES_XXLB
    {
        public CODES_XXLB()
        {
            CODES_XXLBS = new List<CODES_XXLB>();
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Id]
        public virtual int LBID { get; set; }

        /// <summary>
        /// 类别类型
        /// </summary>
        [Property]
        public virtual string LBLX { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        [Property]
        public virtual string LBNAME { get; set; }

        /// <summary>
        /// 类型排序
        /// </summary>
        [Property]
        public virtual int LBORDER { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        [Property]
        public virtual int PARENTID { get; set; }

        /// <summary>
        /// 发布页面
        /// </summary>
        [Property]
        public virtual string FBYM { get; set; }
        
        /// <summary>
        /// 类别对应数据表
        /// </summary>
        [Property]
        public virtual string FBTABLE { get; set; }
        


        public virtual IList<CODES_XXLB> CODES_XXLBS { get; set; }
    }
}
