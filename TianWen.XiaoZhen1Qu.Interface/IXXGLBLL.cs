﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IXXGLBLL
    {
        IDAO DAO { get; set; }

        object LoadYHXX(string YHID, string TYPE, string PageIndex, string PageSize);

        object DeleteYHXX(string[] YHXXIDs);

        object ZDYHXX(string[] YHXXIDs);
    }
}
