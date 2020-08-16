using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionDemo.Helper
{
    /// <summary>
    /// 表达式目录树
    /// </summary>
    public static class ExpressionMapper<Tin, Tout>
    {
        static Func<Tin, Tout> _func;

        static ExpressionMapper()
        {
            if (_func == null)
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(Tin), "p");
                List<MemberBinding> memberBindingList = new List<MemberBinding>();
                //绑定所有属性
                foreach (var prop in typeof(Tout).GetProperties())
                {
                    MemberExpression expression = Expression.Property(parameterExpression, prop.Name);
                    MemberBinding binding = Expression.Bind(prop, expression);
                    memberBindingList.Add(binding);
                }

                //绑定所有字段
                foreach (var prop in typeof(Tout).GetFields())
                {
                    MemberExpression expression = Expression.Field(parameterExpression, prop.Name);
                    MemberBinding binding = Expression.Bind(prop, expression);
                    memberBindingList.Add(binding);
                }

                MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(Tout)), memberBindingList);
                Expression<Func<Tin, Tout>> lamda = Expression.Lambda<Func<Tin, Tout>>(memberInitExpression, new ParameterExpression[] {
                    parameterExpression
                });

                _func = lamda.Compile();
            }
        }
        public static Tout Trans(Tin tin)
        {
            return _func.Invoke(tin);
        }
    }
}
