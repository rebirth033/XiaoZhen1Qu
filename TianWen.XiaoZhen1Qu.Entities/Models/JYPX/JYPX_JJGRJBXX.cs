using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class JYPX_JJGRJBXX
    {
        public JYPX_JJGRJBXX()
        {
            JYPX_JJGRJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 教育培训_家教个人信息ID
        /// </summary>
        [Id]
        public virtual string JYPX_JJGRJBXXID { get; set; }

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
        /// 性别
        /// </summary>
        [Property]
        public virtual string XB { get; set; }

        /// <summary>
        /// 身份
        /// </summary>
        [Property]
        public virtual string SF { get; set; }

        /// <summary>
        /// 家教经验
        /// </summary>
        [Property]
        public virtual string JJJY { get; set; }

        /// <summary>
        /// 辅导阶段
        /// </summary>
        [Property]
        public virtual string FDJD { get; set; }

        /// <summary>
        /// 辅导科目
        /// </summary>
        [Property]
        public virtual string FDKM { get; set; }

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
        public virtual Byte[] BCMS { get; set; }
    }
}
