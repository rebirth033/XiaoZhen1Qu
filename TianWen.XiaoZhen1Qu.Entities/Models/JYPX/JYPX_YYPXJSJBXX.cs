using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class JYPX_YYPXJSJBXX
    {
        public JYPX_YYPXJSJBXX()
        {
            JYPX_YYPXJSJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 教育培训_语言培训教师信息ID
        /// </summary>
        [Id]
        public virtual string JYPX_YYPXJSJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Property]
        public virtual string XM { get; set; }

        /// <summary>
        /// 身份
        /// </summary>
        [Property]
        public virtual string SF { get; set; }

        /// <summary>
        /// 教学科目
        /// </summary>
        [Property]
        public virtual string JXKM { get; set; }

        /// <summary>
        /// 级别水平
        /// </summary>
        [Property]
        public virtual string JBSP { get; set; }

        /// <summary>
        /// 家教经验
        /// </summary>
        [Property]
        public virtual string JJJY { get; set; }

        /// <summary>
        /// 期望时薪_起
        /// </summary>
        [Property]
        public virtual string QWSX_Q { get; set; }

        /// <summary>
        /// 期望时薪_止
        /// </summary>
        [Property]
        public virtual string QWSX_Z { get; set; }

        /// <summary>
        /// 服务区域
        /// </summary>
        [Property]
        public virtual string FWQY { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        [Property]
        public virtual string QY { get; set; }

        /// <summary>
        /// 地段
        /// </summary>
        [Property]
        public virtual string DD { get; set; }

        /// <summary>
        /// 具体地址
        /// </summary>
        [Property]
        public virtual string JTDZ { get; set; }

        /// <summary>
        /// 补充描述
        /// </summary>
        [Property]
        public virtual string BCMS { get; set; }
    }
}
