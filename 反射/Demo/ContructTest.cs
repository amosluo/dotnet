using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 反射.Demo
{
    public class ContructTest
    {
        public ContructTest()
        {
            Console.WriteLine("无参构造函数");
        }
        public ContructTest(string name)
        {
            Console.WriteLine("sring参数构造函数");
        }
        public ContructTest(int age)
        {
            Console.WriteLine("int参构造函数");
        }
        public ContructTest(int? age)
        {
            Console.WriteLine("int?参构造函数");
        }

        public ContructTest(object obj)
        {
            Console.WriteLine("object参构造函数");
        }

        public ContructTest(int age, string name)
        {
            Console.WriteLine("int,string参构造函数");
        }
        public ContructTest(string name,int age)
        {
            Console.WriteLine("string,int参构造函数");
        }
    }
}
