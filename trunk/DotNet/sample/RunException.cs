using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sample
{
    internal class RunException : System.Exception
    {
        public Dictionary<String, Object> States = new Dictionary<String,Object>();
    }
}
