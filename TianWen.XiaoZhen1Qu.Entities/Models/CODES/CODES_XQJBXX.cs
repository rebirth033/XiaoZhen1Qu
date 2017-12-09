using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class CODES_XQJBXX
    {
        public CODES_XQJBXX()
        {
            XQJBXXID = Guid.NewGuid().ToString("N");
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

        /// <summary>
        /// 小区所在市
        /// </summary>
        [Property]
        public virtual string SZS { get; set; }

        /// <summary>
        /// 小区所在县
        /// </summary>
        [Property]
        public virtual string SZX { get; set; }

        /// <summary>
        /// 开发商
        /// </summary>
        [Property]
        public virtual string KFS { get; set; }

        /// <summary>
        /// 物业公司
        /// </summary>
        [Property]
        public virtual string WYGS { get; set; }

        /// <summary>
        /// 物业类型
        /// </summary>
        [Property]
        public virtual string WYLX { get; set; }

        /// <summary>
        /// 物业费
        /// </summary>
        [Property]
        public virtual string WYF { get; set; }

        /// <summary>
        /// 总建面积
        /// </summary>
        [Property]
        public virtual string ZJMJ { get; set; }

        /// <summary>
        /// 总户数
        /// </summary>
        [Property]
        public virtual string ZHS { get; set; }

        /// <summary>
        /// 建筑年代
        /// </summary>
        [Property]
        public virtual string JZND { get; set; }

        /// <summary>
        /// 容积率
        /// </summary>
        [Property]
        public virtual string RJL { get; set; }

        /// <summary>
        /// 停车位
        /// </summary>
        [Property]
        public virtual string TCW { get; set; }

        /// <summary>
        /// 绿化率
        /// </summary>
        [Property]
        public virtual string LHL { get; set; }

    }
}
