using System.Collections.Generic;
using FluentNHibernate.Testing.Values;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CODES_QZZP
    {
        public CODES_QZZP()
        {
            childs = new List<CODES_QZZP>();
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Id]
        public virtual int CODEID { get; set; }

        /// <summary>
        /// 类型名
        /// </summary>
        [Property]
        public virtual string TYPENAME { get; set; }

        /// <summary>
        /// 类型名
        /// </summary>
        [Property]
        public virtual string CODENAME { get; set; }

        /// <summary>
        /// 类型名
        /// </summary>
        [Property]
        public virtual string CODEVALUE { get; set; }

        /// <summary>
        /// 类型名
        /// </summary>
        [Property]
        public virtual int CODEORDER { get; set; }

        /// <summary>
        /// 类型名
        /// </summary>
        [Property]
        public virtual int PARENTID { get; set; }


        /// <summary>
        /// 类型名
        /// </summary>
        [Property]
        public virtual List<CODES_QZZP> childs { get; set; }
    }
}
