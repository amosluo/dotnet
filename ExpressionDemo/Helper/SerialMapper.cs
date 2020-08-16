using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ExpressionDemo.Helper
{
    public class SerialMapper
    {
        public static Tout Trans<Tin, Tout>(Tin tin)
        {
            string tinStr = Newtonsoft.Json.JsonConvert.SerializeObject(tin);
            Tout tout = Newtonsoft.Json.JsonConvert.DeserializeObject<Tout>(tinStr);
            return tout;
        }
    }
}
