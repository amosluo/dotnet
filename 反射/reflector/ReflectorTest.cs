using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 反射.reflector
{
    public class ReflectorTest
    {

        public int PublicField;
        private int privateField;
        public int PublicProp { get; set; }
        public int privateProp { get; set; }

        public event EventHandler PublicEventHandler;
        private event EventHandler PrivateEventHandler;

        public ReflectorTest()
        {
            Assembly assembly = Assembly.Load("反射");
            Type type = assembly.GetType("反射.Demo.ContructTest");

            object o1 = Activator.CreateInstance(type);//无参构造函数
            object o2 = Activator.CreateInstance(type, "luox");//string 参数构造函数
            object o3 = Activator.CreateInstance(type, 123);//int 参数构造函数
            object o4 = Activator.CreateInstance(type, 123, "luox");//int，string 参数构造函数
            //object o5 = Activator.CreateInstance(type, "luox", 123);//string ，int 参数构造函数
            object o5 = Activator.CreateInstance(type, new object[] { "luox", 123 });//string ，int 参数构造函数
            int? a = 1;
            object o6 = Activator.CreateInstance(type, a);//a == null报错，与午餐构造函数冲突，a！=null，走int构造函数，int?无意义
            object o7 = Activator.CreateInstance(type, new object());//ojbect参数构造函数
        }

        public void RelectorMehtod(string name, object age)
        {
            Console.WriteLine($"反射调用方法：name:{name}, age:{age}");
        }
        public void RelectorMehtod(string name, int age)
        {
            Console.WriteLine($"反射调用方法：name:{name}, age(int):{age}");
        }

        private void PrivateMethod(string name, int age)
        {
            Console.WriteLine($"反射调用私有方法：name:{name}, age(int):{age}");
        }

        public static void StaticMethod(string name, int age)
        {
            Console.WriteLine($"反射调用静态方法：name:{name}, age:{age}");
        }

        public void GenericMehtod<T,S>(T t,S s,string exd)
        {
            Console.WriteLine($"反射调用泛型方法：name:{t}, age:{s}, exd:{exd}");
        }
    }
}
