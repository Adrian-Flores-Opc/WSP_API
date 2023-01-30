﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSP.ABSTRACTION.LOGGER
{
    public interface ILoggerInfo
    {
        void Debug(string format, params object[] objects);

        void Debug(string message);

        void Error(string format, params object[] objects);

        void Error(string message);

        void Fatal(string format, params object[] objects);

        void Fatal(string message);
    }
}
