using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 反射.Singleton
{
    public sealed class SingletonDemo
    {
        private static SingletonDemo _instance = null;
        static int count = 0;
        static SingletonDemo()
        {
            Console.WriteLine("静态构造函数");
            ++count;
            _instance = new SingletonDemo();
        }

        private SingletonDemo()
        {
            Console.WriteLine("私有构造函数");
        }

        

        public static SingletonDemo GetInstance()
        {
            return _instance;
        }

        public int GetInstanceCount()
        {
            return count;
        }
    }
}
