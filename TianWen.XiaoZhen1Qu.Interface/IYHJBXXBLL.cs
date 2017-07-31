﻿using System.Data;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IYHJBXXBLL
    {
        IDAO DAO { get; set; }

        DataTable GetYHJBXXListByPage();

        object CreateBasic(YHJBXX yhjbxx);

        string GetObjByYHM(string YHM);

        string GetObjByYHMOrSJ(string YHM);

        object UpdatePassword(string MM, string SJ);

        object UpdateTX(string YHID, string TX);

        object UpdateYHM(string YHID, string YHM);

        object UpdateSJ(string YHID, string SJ);

        object UpdateQQ(string YHID, string QQ);

        object UpdateWB(string YHID, string WB);

        object UpdateWX(string YHID, string WX);

        object MMCZ(string YHID, string JMM, string XMM);

        object GetObjByID(string YHID);

        object SendEmail(string YHID, string YX, string CheckCode);

        object YHYZ(string YHID_Cryptograph, string CheckCode_Cryptograph);
    }
}
