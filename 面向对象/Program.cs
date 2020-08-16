using System;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using 面向对象.继承;

namespace 面向对象
{
    class Program
    {
        static void Main(string[] args)
        {
            //子类静态构造函数先于父类静态构造函数执行
            //父类普通构造函数先于子类普通构造函数执行
            AbstractParent parent = new Child(); //调用子类构造方法之前，会先调用父类构造方法
            parent.Show();//普通方法，子类new隐藏父类，会在编译时决定调用父类的方法--提高效率
            parent.Call();//虚方法，子类覆盖父类方法 ,运行时决定(多态)
            parent.Do();//抽象方法，子类覆盖父类方法,运行时决定(多态)

            parent.ShowAge();//输出2，说明子类与父类共享静态Age变量

            AbstractParent parent2 = new Child(); //调用子类构造方法之前，会先调用父类构造方法
            parent2.ShowAge();//输出2，说明所有子类共享同一个静态Age变量

            //string str = "  ";
            //if (string.IsNullOrWhiteSpace(str))
            //{

            //}

            //Func<int, int, int> func = (m, n) => m * n + 1;
            //Action ac = () => { };
            //Expression<Func<int, int, int>> exp = (m, n) => m * n + 1;
            //var _str = func.Invoke(2,3);
            //ac.Invoke();
            //var i = exp.Compile().Invoke(2, 3);
        }
    }
}
