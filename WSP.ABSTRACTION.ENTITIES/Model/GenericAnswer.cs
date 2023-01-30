using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSP.ABSTRACTION.ENTITIES.Model
{
    public  class GenericAnswer
    {
        public string message { get; set; } = string.Empty;
        public int code { get; set; }
        public bool state { get; set; }
    }
}
