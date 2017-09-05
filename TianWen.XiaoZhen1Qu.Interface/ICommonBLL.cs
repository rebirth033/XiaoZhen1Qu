using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICommonBLL : IBaseBLL
    {
        object GetIDByJCXXIDAndLBID(string JCXXID, string LBID);

        object GetDistrictByGrade(string Grade);

        object GetDistrictBySuperCode(string SuperCode); 
    }
}
