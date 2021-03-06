﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IWDSCBLL : IBaseBLL
    {
        IDAO DAO { get; set; }

        object LoadYHSCXX(string YHID, string PageIndex, string PageSize);

        object DeleteYHSCXX(string YHID, string JCXXID);

        object AddYHSCXX(string YHM, string JCXXID, string TYPE, string LBID, string TYPEID);
    }
}
