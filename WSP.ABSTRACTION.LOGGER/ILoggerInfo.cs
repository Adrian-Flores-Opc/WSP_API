using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSP.ABSTRACTION.LOGGER
{
    public interface ILoggerInfo
    {
        void Information(string format, params object[] objects);
        void Information(string message);

        void Fatal(string format, params object[] objects);
        void Fatal(string message);

        void Warning(string format, params object[] objects);
        void Warning(string message);

        void Error(string format, params object[] objects);
        void Error(string message);

        void Debug(string format, params object[] objects);
        void Debug(string message);

        void Verbose(string format, params object[] objects);
        void Verbose(string message);
    }
}
