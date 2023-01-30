using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSP.ABSTRACTION.DATAACCESS
{
    public class DBOptions
    {
        public List<DBOptionItems> connections { get; set; } = new List<DBOptionItems>();
        public string name { get; set; } = String.Empty;
    }

    public class DBOptionItems
    {
        public string name { get; set; } = String.Empty;
        public string server { get; set; } = String.Empty;
        public string dataBase { get; set; } = String.Empty;
        public string user { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;
    }
}
