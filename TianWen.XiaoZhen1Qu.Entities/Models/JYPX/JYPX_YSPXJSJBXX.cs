using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class JYPX_YSPXJSJBXX
    {
        public JYPX_YSPXJSJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 教育培训_语言培训教师信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

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
        /// 教龄
        /// </summary>
        [Property]
        public virtual string JL { get; set; }

        /// <summary>
        /// 毕业院校
        /// </summary>
        [Property]
        public virtual string BYYX { get; set; }

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
        /// 服务范围
        /// </summary>
        [Property]
        public virtual string FWFW { get; set; }

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
