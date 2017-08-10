using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class DJJDJL
    {
        public DJJDJL()
        {
            DJJDJLID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 冻结解冻记录ID
        /// </summary>
        [Id]
        public virtual string DJJDJLID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Property]
        public virtual DateTime CJSJ { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Property]
        public virtual decimal JE { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Property]
        public virtual string LX { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Property]
        public virtual string BZ { get; set; }

        /// <summary>
        /// 用户账户信息ID
        /// </summary>
        [Property]
        public virtual string YHZHXXID { get; set; }
    }
}
