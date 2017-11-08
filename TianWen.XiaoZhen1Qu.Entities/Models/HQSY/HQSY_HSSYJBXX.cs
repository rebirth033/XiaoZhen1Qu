using System;
using NHibernate.Mapping.Attributes;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public class HQSY_HSSYJBXX
    {
        public HQSY_HSSYJBXX()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 婚庆摄影_婚纱摄影基本信息ID
        /// </summary>
        [Id]
        public virtual string ID { get; set; }

        /// <summary>
        /// 基础信息ID
        /// </summary>
        [Property]
        public virtual string JCXXID { get; set; }

        /// <summary>
        /// 影楼/工作室
        /// </summary>
        [Property]
        public virtual string YLGZS { get; set; }

        /// <summary>
        /// 拍摄地点
        /// </summary>
        [Property]
        public virtual string PSDD { get; set; }

        /// <summary>
        /// 拍摄风格
        /// </summary>
        [Property]
        public virtual string PSFG { get; set; }

        /// <summary>
        /// 服务保证
        /// </summary>
        [Property]
        public virtual string FWBZ { get; set; }

        /// <summary>
        /// 服装套数
        /// </summary>
        [Property]
        public virtual string FZTS { get; set; }

        /// <summary>
        /// 服装是否分区
        /// </summary>
        [Property]
        public virtual string FZSFFQ { get; set; }

        /// <summary>
        /// 服装配饰收费
        /// </summary>
        [Property]
        public virtual string FZPSSF { get; set; }

        /// <summary>
        /// 套系内化妆造型
        /// </summary>
        [Property]
        public virtual string TXNHZZX { get; set; }

        /// <summary>
        /// 套系底片数
        /// </summary>
        [Property]
        public virtual string TXDPS { get; set; }

        /// <summary>
        /// 套系精修及入册数
        /// </summary>
        [Property]
        public virtual string TXJXJRCS { get; set; }

        /// <summary>
        /// 精修刻盘赠送
        /// </summary>
        [Property]
        public virtual string JXKPZS { get; set; }

        /// <summary>
        /// 底片赠送
        /// </summary>
        [Property]
        public virtual string DPZS { get; set; }

        /// <summary>
        /// 加片收费
        /// </summary>
        [Property]
        public virtual string JPSF { get; set; }

        /// <summary>
        /// 加底收费
        /// </summary>
        [Property]
        public virtual string JDSF { get; set; }

        /// <summary>
        /// 套系相册数量
        /// </summary>
        [Property]
        public virtual string TXXCSL { get; set; }

        /// <summary>
        /// 套系摆件数量
        /// </summary>
        [Property]
        public virtual string TXBJSL { get; set; }

        /// <summary>
        /// 拍摄时间
        /// </summary>
        [Property]
        public virtual string PSSJ { get; set; }

        /// <summary>
        /// 包含餐饮
        /// </summary>
        [Property]
        public virtual string BHCY { get; set; }

        /// <summary>
        /// 价格 
        /// </summary>
        [Property]
        public virtual string JG { get; set; }

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
