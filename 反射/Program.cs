using 反射.Demo;
using 反射.reflector;
using 反射.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 反射.Generic;

namespace CacheConsole
{
    delegate void RunDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            {
                //测试反射调用构造函数
                ReflectorTest ct = new ReflectorTest();
            }

            {

                //测试单例
                Console.WriteLine("---------------测试单例----------------");
                SingletonDemo singletonDemo1 = SingletonDemo.GetInstance();
                SingletonDemo singletonDemo2 = SingletonDemo.GetInstance();
                SingletonDemo singletonDemo3 = SingletonDemo.GetInstance();
                SingletonDemo singletonDemo4 = SingletonDemo.GetInstance();
                SingletonDemo singletonDemo5 = SingletonDemo.GetInstance();
                Console.WriteLine(singletonDemo5.GetInstanceCount());
                Console.WriteLine(object.ReferenceEquals(singletonDemo1, singletonDemo5));

                //反射破坏单例
                Console.WriteLine("---------------测试反射破坏单例----------------");
                Assembly assembly = Assembly.Load("反射");
                Type type = assembly.GetType("反射.Singleton.SingletonDemo");
                SingletonDemo singleton1 = (SingletonDemo)Activator.CreateInstance(type, true);//调用私有构造函数来创建对象（参数true）
                SingletonDemo singleton2 = (SingletonDemo)Activator.CreateInstance(type, true);
                Console.WriteLine(singleton1.GetInstanceCount());
                Console.WriteLine(singleton2.GetInstanceCount());

                Console.WriteLine(object.ReferenceEquals(singleton1, singleton2));
            }
            {
                Console.WriteLine("---------------测试泛型----------------");
                Assembly assembly = Assembly.Load("反射");
                Type type = assembly.GetType("反射.Generic.GenericDemo`2").MakeGenericType(new Type[] { typeof(string), typeof(int) });//`2:代表泛型类有两个泛型参数（T,S）占位符，MakeGenericType：确定泛型参数类型，以供泛型类的实例化

                GenericDemo<string, int> demo = (GenericDemo<string, int>)(Activator.CreateInstance(type));
            }
            {
                Console.WriteLine("---------------测试调用方法----------------");
                Assembly assembly = Assembly.Load("反射");
                Type type = assembly.GetType("反射.reflector.ReflectorTest");
                object obj = Activator.CreateInstance(type);
                MethodInfo method = type.GetMethod("RelectorMehtod", new Type[] { typeof(string), typeof(int) });//如果类中有两个及以上同名方法，则需要指定new type[]参数，以区分是哪个重载方法
                method.Invoke(obj, new object[] { "luox", 123 });

                Console.WriteLine("---------------测试调用私有方法----------------");
                MethodInfo privateMethod = type.GetMethod("PrivateMethod", BindingFlags.Instance | BindingFlags.NonPublic);//如果类中有两个及以上同名方法，则需要指定new type[]参数，以区分是哪个重载方法
                privateMethod.Invoke(obj, new object[] { "luox", 123 });

                Console.WriteLine("---------------测试调用静态方法----------------");
                MethodInfo staticMethod = type.GetMethod("StaticMethod");
                //method.Invoke(staticMethod, new object[] { "luox", 123 });
                staticMethod.Invoke(null, new object[] { "luox", 123 });

                MethodInfo genericMethod = type.GetMethod("GenericMehtod").MakeGenericMethod(new Type[] { typeof(string), typeof(int) });//type[]代表泛型类型，按顺序填写
                genericMethod.Invoke(obj, new object[] { "luox", 123,"exd" });
            }

            {
                Assembly assembly = Assembly.Load("反射");
                Type type = assembly.GetType("反射.reflector.ReflectorTest");

                Console.WriteLine("---------------测试获取成员变量----------------");
                foreach (var item in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    Console.WriteLine($"成员名称:{item.DeclaringType} {item.MemberType} {item.Name}");
                }

                Console.WriteLine("---------------测试获取属性----------------");
                foreach (var item in type.GetProperties())
                {
                    Console.WriteLine($"成员名称:{item.DeclaringType} {item.MemberType} {item.Name}");
                }

                Console.WriteLine("---------------测试获取事件----------------");
                foreach (var item in type.GetEvents(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    Console.WriteLine($"成员名称:{item.DeclaringType} {item.MemberType} {item.Name}");
                }
            }
            Console.ReadLine();


        }
    }

    class Dog
    {
        public void Run()
        {
            Console.WriteLine("汪汪");
        }
        public void Run2()
        {
            string a = "a";
            int b = Convert.ToInt32(a);
            Console.WriteLine("汪汪");
        }
    }
}
