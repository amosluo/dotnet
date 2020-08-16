using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionDemo.Helper
{
    public class ReflectionMapper
    {
        public static Tout Trans<Tin, Tout>(Tin tin)
        {
            Tout tout = Activator.CreateInstance<Tout>();
            foreach (var outItem in tout.GetType().GetProperties())
            {
                outItem.SetValue(tout, tin.GetType().GetProperty(outItem.Name).GetValue(tin));
            }
            return tout;
        }
    }
}
