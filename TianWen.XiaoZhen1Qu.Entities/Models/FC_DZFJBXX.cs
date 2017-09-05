using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class FC_DZFJBXX
    {
        public FC_DZFJBXX()
        {
            FC_DZFJBXXID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 短租房基本信息ID
        /// </summary>
        [Id]
        public virtual string FC_DZFJBXXID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 房屋类型
        /// </summary>
        [Property]
        public virtual string FWLX { get; set; }

        /// <summary>
        /// 最短租期
        /// </summary>
        [Property]
        public virtual int ZDZQ { get; set; }

        /// <summary>
        /// 租金
        /// </summary>
        [Property]
        public virtual int ZJ { get; set; }

        /// <summary>
        /// 宜租人数
        /// </summary>
        [Property]
        public virtual int YZRS { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        [Property]
        public virtual int MJ { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Property]
        public virtual string DZ { get; set; }

        /// <summary>
        /// 出租方式
        /// </summary>
        [Property]
        public virtual int CZFS { get; set; }

        /// <summary>
        /// 房源描述
        /// </summary>
        [Property]
        public virtual string FYMS { get; set; }
    }
}
