using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionDemo.Helper;

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

            {
                int max = 1_000_000;
                Console.WriteLine($"----------------{max}次循环比较耗时：反射/序列化/表达式目录树-----------------");
                //因为通过序列化得到实体涉及到序列化和反序列化的过程，所有耗时更多（基本上需要比反射多一倍的时间消耗）
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 1; i <= max; i++)
                {
                    PeopleDto reflectionPeopleDto = ReflectionMapper.Trans<People, PeopleDto>(new People
                    {
                        Id = 1,
                        Age = 8,
                        Name = "luox"
                    });
                }
                sw.Stop();
                Console.WriteLine($"反射耗时：{sw.ElapsedMilliseconds}ms");

                sw.Restart();
                for (int i = 1; i <= max; i++)
                {
                    PeopleDto serialPeopleDto = SerialMapper.Trans<People, PeopleDto>(new People
                    {
                        Id = 1,
                        Age = 18,
                        Name = "luox"
                    });
                }
                sw.Stop();
                Console.WriteLine($"序列化耗时：{sw.ElapsedMilliseconds}ms");


                sw.Restart();
                for (int i = 1; i <= max; i++)
                {
                    PeopleDto dto = ExpressionMapper<People, PeopleDto>.Trans(new People
                    {
                        Id = 1,
                        Age = 18,
                        Name = "luox"
                    });

                    string str = "";
                }
                sw.Stop();
                Console.WriteLine($"表达式目录树耗时：{sw.ElapsedMilliseconds}ms");



                Console.ReadLine();
            }

        }
    }
}
