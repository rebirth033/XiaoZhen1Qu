﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJMCXBLL : IBaseBLL
    {
        object LoadZSJMXX(string TYPE, string Condition, string PageIndex, string PageSize);

        object LoadZSJMXX(string TYPE, string ID);
    }
}