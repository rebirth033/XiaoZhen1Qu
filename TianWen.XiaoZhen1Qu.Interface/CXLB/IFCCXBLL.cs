﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface.CXLB
{
    public interface IFCCXBLL : IBaseBLL
    {
        object LoadFCXX(string TYPE, string PageIndex, string PageSize);
    }
}