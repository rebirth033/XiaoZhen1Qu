using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class YHJBXX
    {
        public YHJBXX()
        {
            YHID = Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Id]
        public virtual string YHID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Property]
        public virtual string YHM { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Property]
        public virtual string MM { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        [Property]
        public virtual DateTime SQRQ { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [Property]
        public virtual string ZSXM { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Property]
        public virtual int XB { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Property]
        public virtual DateTime CSRQ { get; set; }

        /// <summary>
        /// 通讯地址
        /// </summary>
        [Property]
        public virtual string TXDZ { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        [Property]
        public virtual string YB { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        [Property]
        public virtual string GXQM { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Property]
        public virtual string SJ { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [Property]
        public virtual string QQ { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [Property]
        public virtual string DZYJ { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Property]
        public virtual string TX { get; set; }

        /// <summary>
        /// 信用等级
        /// </summary>
        [Property]
        public virtual int XYDJ { get; set; }
    }
}
