using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class XQJBXX
    {
        public XQJBXX()
        {
            XQJBXXID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 小区基本信息ID
        /// </summary>
        [Id]
        public virtual string XQJBXXID { get; set; }

        /// <summary>
        /// 小区名称
        /// </summary>
        [Property]
        public virtual string XQMC { get; set; }

        /// <summary>
        /// 小区地址
        /// </summary>
        [Property]
        public virtual string XQDZ { get; set; }
        
        /// <summary>
        /// 小区名称拼音
        /// </summary>
        [Property]
        public virtual string XQMCPY { get; set; }
                
        /// <summary>
        /// 小区名称拼音去空格
        /// </summary>
        [Property]
        public virtual string XQMCPYQKG { get; set; }

        /// <summary>
        /// 小区名称拼音首字母
        /// </summary>
        [Property]
        public virtual string XQMCPYSZM { get; set; }

    }
}
