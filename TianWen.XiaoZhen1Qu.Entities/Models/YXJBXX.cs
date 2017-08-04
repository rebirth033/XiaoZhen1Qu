using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class YXJBXX
    {
        public YXJBXX()
        {

        }
        /// <summary>
        /// 游戏基本信息ID
        /// </summary>
        [Id]
        public virtual string YXJBXXID { get; set; }

        /// <summary>
        /// 游戏名称
        /// </summary>
        [Property]
        public virtual string YXMC { get; set; }
        
        /// <summary>
        /// 是否热门游戏
        /// </summary>
        [Property]
        public virtual int SFRMYX { get; set; }
                
        /// <summary>
        /// 游戏名称首字母
        /// </summary>
        [Property]
        public virtual string YXMCSZM { get; set; }
    }
}
