using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCantine.Help
{
    static class ObjectHelper
    {
        public static void Dump(this object data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            Trace.WriteLine(json);
        }
    }
}
