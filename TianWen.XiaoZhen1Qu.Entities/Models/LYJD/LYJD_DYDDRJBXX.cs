using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class LYJD_DYDDRJBXX
    {
        public LYJD_DYDDRJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 旅游酒店_导游/当地人信息ID
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
        /// 性别
        /// </summary>
        [Property]
        public virtual string XB { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Property]
        public virtual string NL { get; set; }

        /// <summary>
        /// 导游类型
        /// </summary>
        [Property]
        public virtual string DYLX { get; set; }

        /// <summary>
        /// 导游语种
        /// </summary>
        [Property]
        public virtual string DYYZ { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [Property]
        public virtual string XL { get; set; }

        /// <summary>
        /// 带团经验
        /// </summary>
        [Property]
        public virtual string DTJY { get; set; }

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
