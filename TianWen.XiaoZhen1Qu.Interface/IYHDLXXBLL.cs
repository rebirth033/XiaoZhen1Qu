using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IYHDLXXBLL : IBaseBLL
    {
        IDAO DAO { get; set; }

        object CheckLogin(string YHM, string MM, string SessionID);

        object AutoLogin(string YHM, string SessionID);

        YHJBXX AddUserBySJ(string SJ);
    }
}
