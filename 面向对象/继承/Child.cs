using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace 面向对象.继承
{
    public class Child : AbstractParent
    {
        static Child()
        {
            Age++;
        }
        public Child()
        {
            Console.WriteLine("子类构造方法");
        }
        public new void Show()
        {
            Console.WriteLine("子类show方法");
        }

        public override void Call()
        {
            Console.WriteLine("子类Call方法");
        }
        public override void Do()
        {
            Console.WriteLine("子类Do方法");
        }

        public override void ShowAge()
        {
            Console.WriteLine($"子类Age:{Age}");
        }
    }
}
