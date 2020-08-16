using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using ExpressionDemo.Exd;
using ExpressionDemo.Helper;
using ExpressionDemo.Visitor;

namespace ExpressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //{
            //    Console.WriteLine("***************Func<int,int,int> func = (m,n)=> m * n + 1****************");
            //    Console.WriteLine($"m:{2}, n:{3}");
            //    Func<int, int, int> func = (m, n) => m * n + 1;
            //    Expression<Func<int, int, int>> exp = (m, n) => m * n + 1;
            //    Console.WriteLine(func.Invoke(2, 3));
            //    Console.WriteLine("***************Expression<Func<int, int, int>> exp = (m, n) => m * n + 1****************");
            //    Console.WriteLine($"m:{2}, n:{3}");

            //    Console.WriteLine(exp.Compile());
            //    Console.WriteLine(exp.Compile().Invoke(2, 3));
            //}

            //{
            //    //拼装表达式目录树
            //    Console.WriteLine("***************手动拼装 Expression<Func<int, int, int>> exp = () => m + n****************");
            //    Console.WriteLine($"m:{12}, n:{34}");
            //    //Expression<Func<int, int, int>> exp = () => m + n;
            //    ConstantExpression const1 = Expression.Constant(12);
            //    ConstantExpression const2 = Expression.Constant(34);
            //    BinaryExpression plus = Expression.Add(const1, const2);
            //    Expression<Func<int>> exp = Expression.Lambda<Func<int>>(plus);

            //    var i = exp.Compile().Invoke();
            //    Console.WriteLine(i);
            //}
            //{
            //    //拼装表达式目录树2
            //    Console.WriteLine("***************手动拼装 Expression<Func<int, int, int>> exp = (m, n) => m * n + m + n + 2****************");
            //    Console.WriteLine($"m:{3}, n:{5}");
            //    Expression<Func<int, int, int>> exp = (m, n) => m * n + m + n + 2;
            //    ConstantExpression constant = Expression.Constant(2);

            //    ParameterExpression m = Expression.Parameter(typeof(int), "m");
            //    ParameterExpression n = Expression.Parameter(typeof(int), "n");
            //    var multiply = Expression.Multiply(m, n);
            //    var plus1 = Expression.Add(multiply, m);
            //    var plus2 = Expression.Add(plus1, n);
            //    var plus3 = Expression.Add(plus2, constant);

            //    Expression<Func<int, int, int>> exp2 = Expression.Lambda<Func<int, int, int>>(plus3, m, n);
            //    var result = exp2.Compile().Invoke(3, 5);
            //    Console.WriteLine(result);
            //}

            //{
            //    //拼装表达式目录树3
            //    Console.WriteLine("***************手动拼装 Expression<Func<Student, bool>> exp = (p) => p.Id.ToString().Equals(\"3\")****************");
            //    Expression<Func<Student, bool>> exp = (p) => p.Id.ToString().Equals("3");
            //    ParameterExpression parmExp = Expression.Parameter(typeof(Student), "p");
            //    FieldInfo fieldInfo = typeof(Student).GetField("Id");
            //    var fieldExp = Expression.Field(parmExp, fieldInfo);
            //    var toString = typeof(int).GetMethod("ToString",new Type[] { });
            //    var call1 = Expression.Call(fieldExp, toString);
            //    var equals = typeof(string).GetMethod("Equals", new Type[] {typeof(string) });
            //    var call2 = Expression.Call(call1, equals, Expression.Constant("5"));


            //    Expression<Func<Student, bool>> exp2 = Expression.Lambda<Func<Student, bool>>(call2, parmExp);

            //    Student stu1 = new Student() { Id = 5};
            //    var result1 = exp2.Compile().Invoke(stu1);
            //    Console.WriteLine(result1);

            //    Student stu2 = new Student() { Id = 3 };
            //    var result2 = exp2.Compile().Invoke(stu2);
            //    Console.WriteLine(result2);
            //}

            //{
            //    int max = 1_000_000;
            //    Console.WriteLine($"----------------{max}次循环比较耗时：反射/序列化/表达式目录树-----------------");
            //    //因为通过序列化得到实体涉及到序列化和反序列化的过程，所有耗时更多（基本上需要比反射多一倍的时间消耗）
            //    Stopwatch sw = new Stopwatch();
            //    sw.Start();
            //    for (int i = 1; i <= max; i++)
            //    {
            //        PeopleDto reflectionPeopleDto = ReflectionMapper.Trans<People, PeopleDto>(new People
            //        {
            //            Id = 1,
            //            Age = 8,
            //            Name = "luox"
            //        });
            //    }
            //    sw.Stop();
            //    Console.WriteLine($"反射耗时：{sw.ElapsedMilliseconds}ms");

            //    sw.Restart();
            //    for (int i = 1; i <= max; i++)
            //    {
            //        PeopleDto serialPeopleDto = SerialMapper.Trans<People, PeopleDto>(new People
            //        {
            //            Id = 1,
            //            Age = 18,
            //            Name = "luox"
            //        });
            //    }
            //    sw.Stop();
            //    Console.WriteLine($"序列化耗时：{sw.ElapsedMilliseconds}ms");


            //    sw.Restart();
            //    for (int i = 1; i <= max; i++)
            //    {
            //        PeopleDto dto = ExpressionMapper<People, PeopleDto>.Trans(new People
            //        {
            //            Id = 1,
            //            Age = 18,
            //            Name = "luox"
            //        });

            //        string str = "";
            //    }
            //    sw.Stop();
            //    Console.WriteLine($"表达式目录树耗时：{sw.ElapsedMilliseconds}ms");
            //    
            //}
            //{
            //    Expression<Func<Student, bool>> exp = s => s.Id > 1 && s.Age > 15 && s.Name.Contains("lx") && (1 + 1) > 1;
            //    OperationVisitor ov = new OperationVisitor();
            //    ov.Modify(exp);

            //    int m = 5;
            //    int n = 3;

            //    Expression<Func<int, int, int>> exp2 = (a, b) => a* b + a + b;
            //    OperationVisitor ov2 = new OperationVisitor();
            //    var rst = ((Expression<Func<int, int, int>>)(ov.Modify(exp2))).Compile().Invoke(5, 3);
            //    Console.WriteLine($"{5},{3} = {rst}");
            //}
            //{
            //    Console.WriteLine($"-------------------------模拟生成SQL条件-------------------------");
            //    Expression<Func<Student, bool>> exp = (stu) => stu.Id > 2 && stu.Age < 20 && stu.Name.Contains("lx") && stu.Name.StartsWith("lx") && stu.Name.EndsWith("lx");
            //    ConditionBuilderVisitor visitor = new ConditionBuilderVisitor();
            //    visitor.Visit(exp);
            //    Console.WriteLine(visitor.Condition());
            //}

            {
                Console.WriteLine($"-------------------------模拟表达式and/or/not-------------------------");
                List<Student> list = new List<Student>();
                list.Add(new Student { Id = 1, Age = 2, Name = "lx" });
                list.Add(new Student { Id = 5, Age = 8, Name = "lx" });
                list.Add(new Student { Id = 10, Age = 15, Name = "lx" });

                foreach (var item in list)
                {
                    Console.WriteLine($"Id:{item.Id}, Age:{item.Age}, Name:{item.Name}");
                }

                Expression<Func<Student, bool>> exp1 = stu => stu.Id > 2 && stu.Age > 5;
                Expression<Func<Student, bool>> exp2 = exp1.And<Student>(stu => stu.Age > 8);

                var list1 = list.Where(exp1.Compile()).ToList();
                var list2 = list.Where(exp2.Compile()).ToList();

                Console.WriteLine($"-------------{exp1}-------------");
                foreach (var item in list1)
                {
                    Console.WriteLine($"Id:{item.Id}, Age:{item.Age}, Name:{item.Name}");
                }
                Console.WriteLine($"-------------{exp2}-------------");
                foreach (var item in list2)
                {
                    Console.WriteLine($"Id:{item.Id}, Age:{item.Age}, Name:{item.Name}");
                }

                Expression<Func<Student, bool>> exp3 = exp1.Or<Student>(stu => stu.Name.Contains("lx"));
                var list3 = list.Where(exp3.Compile()).ToList();
                Console.WriteLine($"-------------{exp3}-------------");
                foreach (var item in list3)
                {
                    Console.WriteLine($"Id:{item.Id}, Age:{item.Age}, Name:{item.Name}");
                }

                Expression<Func<Student, bool>> exp4 = stu => stu.Age == 8;
                var list4 = list.Where(exp4.Not<Student>().Compile()).ToList();
                Console.WriteLine($"-------------{exp4}-------------");
                foreach (var item in list4)
                {
                    Console.WriteLine($"Id:{item.Id}, Age:{item.Age}, Name:{item.Name}");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
