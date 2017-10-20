using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class ES_SJSM_ESSJJBXX
    {
        public ES_SJSM_ESSJJBXX()
        {
            ES_SJSM_ESSJJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 写字楼基本信息ID
        /// </summary>
        [Id]
        public virtual string ES_SJSM_ESSJJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 供求
        /// </summary>
        [Property]
        public virtual string GQ { get; set; }

        /// <summary>
        /// 手机品牌
        /// </summary>
        [Property]
        public virtual string SJPP { get; set; }

        /// <summary>
        /// 手机型号
        /// </summary>
        [Property]
        public virtual string SJXH { get; set; }

        /// <summary>
        /// 使用情况
        /// </summary>
        [Property]
        public virtual string SYQK { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [Property]
        public virtual string JG { get; set; }

        /// <summary>
        /// 特色标签
        /// </summary>
        [Property]
        public virtual string TSBQ { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual Byte[] BCMS { get; set; }

        /// <summary>
        /// 交易区域
        /// </summary>
        [Property]
        public virtual string JYQY { get; set; }

        /// <summary>
        /// 交易地段
        /// </summary>
        [Property]
        public virtual string JYDD { get; set; }
    }
}
