﻿using System;
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

        object GetDistrictByShortName(string ShortName);

        object GetDistrictBySuperCode(string SuperCode);

        object GetDistrictTJByXZQDM(string XZQDM);

        object GetDistrictXQJByXZQDM(string XZQDM);

        object GetAllDistrictByXZQDM(string XZQDM);

        object LoadCommonXX(string TYPE, string KEY, string PageIndex, string PageSize, string OrderColumn, string OrderType, string XZQDM);
    }
}
