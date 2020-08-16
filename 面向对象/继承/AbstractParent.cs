using System;
using System.Collections.Generic;
using System.Text;

namespace 面向对象.继承
{
    public abstract class AbstractParent
    {
        public static int Age = 0;

        static AbstractParent(){
            Age++;
        }

        public AbstractParent()
        {
            Console.WriteLine("实例化抽象类构造方法");
        }

        public void Show()
        {
            Console.WriteLine("父类show方法");
        }

        public virtual void Call()
        {
            Console.WriteLine("父类Call方法");
        }

        public abstract void Do();

        public virtual void ShowAge()
        {
            Console.WriteLine($"子类Age:{Age}");
        }

    }
}
