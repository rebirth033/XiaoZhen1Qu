﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICWCXBLL : IBaseBLL
    {
        object LoadCWXX(string TYPE, string Condition, string PageIndex, string PageSize);

        object LoadCWXX(string TYPE, string ID);
    }
}
