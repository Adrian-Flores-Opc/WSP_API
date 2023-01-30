using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSP.ABSTRACTION.SECRYPT
{
    internal interface IManagerSecrypt
    {
        string Encriptar(string value);
        string Desencriptar(string value);
        Tuple<bool, string> Check();
    }
}
