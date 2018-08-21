using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.ViewModels.Common;

namespace TianWen.XiaoZhen1Qu.Entities.ViewModels.CL
{
    public class CL_JCView : BaseView
    {
        //车辆_轿车信息
        public string ID { get; set; }
        public string CLYS { get; set; }
        public int SPNF { get; set; }
        public string SPYF { get; set; }
        public string JG { get; set; }
        public string PP { get; set; }
        public string CX { get; set; }
        public string KS { get; set; }
        public string SGMS { get; set; }
        public string NJDQNF { get; set; }
        public string NJDQYF { get; set; }
        public string JQXDQNF { get; set; }
        public string JQXDQYF { get; set; }
        public string SFDQBY { get; set; }
        public string SYXDQNF { get; set; }
        public int XSLC { get; set; }
        public string BHGHFY { get; set; }
        public string ZCFQFK { get; set; }
        public string PZSZSF { get; set; }
        public string PZSZCS { get; set; }
        public string SFYDY { get; set; }
        public string CLJZPZ { get; set; }
        public string GHCS { get; set; }
        public string QY { get; set; }
        public string DD { get; set; }
        public string JTDZ { get; set; }
        //车辆_轿车详细参数
        public virtual decimal PL { get; set; }
        public virtual string BSX { get; set; }
        public virtual string QDFS { get; set; }
        public virtual string YH { get; set; }
        public virtual string NK { get; set; }
        public virtual string SSRQ { get; set; }
        public virtual string TCRQ { get; set; }
        public virtual string HBBZ { get; set; }
        public virtual string CDSX { get; set; }
        public virtual string ZCZB { get; set; }
        public virtual string CKG { get; set; }
        public virtual string ZJ { get; set; }
        public virtual string QLJ { get; set; }
        public virtual string HLJ { get; set; }
        public virtual string ZXLDJX { get; set; }
        public virtual string CSJG { get; set; }
        public virtual string ZBZL { get; set; }
        public virtual string ZZL { get; set; }
        public virtual string ZAIZL { get; set; }
        public virtual string XLXRJ { get; set; }
        public virtual string CMS { get; set; }
        public virtual string ZWS { get; set; }
        public virtual string FZXS { get; set; }
        public virtual string FDJXH { get; set; }
        public virtual string JQXS { get; set; }
        public virtual string QGPLXS { get; set; }
        public virtual string YXRJ { get; set; }
        public virtual string QGS { get; set; }
        public virtual string MGQMS { get; set; }
        public virtual string YSB { get; set; }
        public virtual string QMJG { get; set; }
        public virtual string GJ { get; set; }
        public virtual string CC { get; set; }
        public virtual string ZDML { get; set; }
        public virtual string ZDGL { get; set; }
        public virtual string ZDGLZS { get; set; }
        public virtual string ZDNJ { get; set; }
        public virtual string ZDNJZS { get; set; }
        public virtual string FDJTYJS { get; set; }
        public virtual string RYBJ { get; set; }
        public virtual string RLXS { get; set; }
        public virtual string GYFS { get; set; }
        public virtual string GGCL { get; set; }
        public virtual string GTCL { get; set; }
        public virtual string ZGCS { get; set; }
        public virtual string GFJS { get; set; }
        public virtual string BSXLX { get; set; }
        public virtual string DWGS { get; set; }
        public virtual string BSXJC { get; set; }
        public virtual string SQXS { get; set; }
        public virtual string QXFLX { get; set; }
        public virtual string HXGLX { get; set; }
        public virtual string ZYCSQJG { get; set; }
        public virtual string ZLLX { get; set; }
        public virtual string CTJG { get; set; }
        public virtual string QZDQLX { get; set; }
        public virtual string HZDQLX { get; set; }
        public virtual string ZCZDLX { get; set; }
        public virtual string QLTGG { get; set; }
        public virtual string HLTGG { get; set; }
        public virtual string BTFQCC { get; set; }
        public virtual string JSZAQQN { get; set; }
        public virtual string FJSAQQN { get; set; }
        public virtual string QPCQN { get; set; }
        public virtual string HPCQN { get; set; }
        public virtual string QPTBQN { get; set; }
        public virtual string HPTBQN { get; set; }
        public virtual string QBQN { get; set; }
        public virtual string TYJCZZ { get; set; }
        public virtual string LTYJSXS { get; set; }
        public virtual string AQDWXTS { get; set; }
        public virtual string ISOFIX { get; set; }
        public virtual string LATCH { get; set; }
        public virtual string FDJDZFD { get; set; }
        public virtual string CNZKS { get; set; }
        public virtual string YKYS { get; set; }
        public virtual string WYSQDXT { get; set; }
        public virtual string YSXT { get; set; }
        public virtual string ZDAQ { get; set; }
        public virtual string ABSFBSSC { get; set; }
        public virtual string ZDLFP { get; set; }
        public virtual string XCFZ { get; set; }
        public virtual string QYLKZXT { get; set; }
        public virtual string CSWDKZ { get; set; }
        public virtual string ZDZCSPFZ { get; set; }
        public virtual string DPHJXT { get; set; }
        public virtual string KBXG { get; set; }
        public virtual string KQXG { get; set; }
        public virtual string ZDZXXT { get; set; }
        public virtual string BXTSXT { get; set; }
        public virtual string KBZXB { get; set; }
        public virtual string QQXHCSQ { get; set; }
        public virtual string HQXHCSQ { get; set; }
        public virtual string ZYCXQSZGN { get; set; }
        public virtual string TQ { get; set; }
        public virtual string QJTQ { get; set; }
        public virtual string YDBTZ { get; set; }
        public virtual string LHJLQ { get; set; }
        public virtual string DDXHM { get; set; }
        public virtual string ZPFXP { get; set; }
        public virtual string FXPSXTJ { get; set; }
        public virtual string FXPQHTJ { get; set; }
        public virtual string FXPDDTJ { get; set; }
        public virtual string DGNFXP { get; set; }
        public virtual string FSPHD { get; set; }
        public virtual string DSXHKZ { get; set; }
        public virtual string ZXSXHKZ { get; set; }
        public virtual string QLD { get; set; }
        public virtual string HDCLD { get; set; }
        public virtual string DCYX { get; set; }
        public virtual string QJSXT { get; set; }
        public virtual string ZDDCRW { get; set; }
        public virtual string XCDNXSP { get; set; }
        public virtual string TTSZXS { get; set; }
        public virtual string PZZY { get; set; }
        public virtual string YDZY { get; set; }
        public virtual string ZYGDTJ { get; set; }
        public virtual string YBZCTJ { get; set; }
        public virtual string JBZCTJ { get; set; }
        public virtual string QPZYDDTJ { get; set; }
        public virtual string DEPZYKBTJ { get; set; }
        public virtual string DEPZYYD { get; set; }
        public virtual string HPZYDDTJ { get; set; }
        public virtual string DDZYJY { get; set; }
        public virtual string QPZYJR { get; set; }
        public virtual string HPZYJR { get; set; }
        public virtual string ZYTF { get; set; }
        public virtual string ZYAM { get; set; }
        public virtual string HPZYZTFD { get; set; }
        public virtual string HPZYABLFD { get; set; }
        public virtual string DSPZY { get; set; }
        public virtual string QZZYFS { get; set; }
        public virtual string HZZYFS { get; set; }
        public virtual string HPBJ { get; set; }
        public virtual string DDHBX { get; set; }
        public virtual string GPSDHXT { get; set; }
        public virtual string WLHDXT { get; set; }
        public virtual string ZKTYJP { get; set; }
        public virtual string DMTKZXT { get; set; }
        public virtual string NZYP { get; set; }
        public virtual string LYDHXT { get; set; }
        public virtual string CZDS { get; set; }
        public virtual string ZKYJPFPXS { get; set; }
        public virtual string HPYJP { get; set; }
        public virtual string WJYYZC { get; set; }
        public virtual string MP3ZC { get; set; }
        public virtual string DDCD { get; set; }
        public virtual string XNDDCD { get; set; }
        public virtual string DDDVD { get; set; }
        public virtual string DUODDVD { get; set; }
        public virtual string LBYSQXTGS { get; set; }
        public virtual string XQDD { get; set; }
        public virtual string LEDDD { get; set; }
        public virtual string RJXCD { get; set; }
        public virtual string GYDD { get; set; }
        public virtual string ZXFZD { get; set; }
        public virtual string QWD { get; set; }
        public virtual string DDGDKT { get; set; }
        public virtual string DDQXZZ { get; set; }
        public virtual string CNFWD { get; set; }
        public virtual string QDDCC { get; set; }
        public virtual string HDDCC { get; set; }
        public virtual string CCFJSGN { get; set; }
        public virtual string FZWXGRBL { get; set; }
        public virtual string HSJDDTJ { get; set; }
        public virtual string HSJJR { get; set; }
        public virtual string HSJZDFXM { get; set; }
        public virtual string HSJDDZD { get; set; }
        public virtual string HSJJY { get; set; }
        public virtual string HFDZYL { get; set; }
        public virtual string HCCZYL { get; set; }
        public virtual string ZYBHZJ { get; set; }
        public virtual string HYS { get; set; }
        public virtual string GYYS { get; set; }
        public virtual string SDZDKT { get; set; }
        public virtual string HPDLKT { get; set; }
        public virtual string HPCFK { get; set; }
        public virtual string WDFQKZ { get; set; }
        public virtual string CNKQJH { get; set; }
        public virtual string CZBX { get; set; }
    }
}
