using ExpressionDemo.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Exd
{
    public static class SqlExd
    {
        public static string ToSqlOperator(this ExpressionType expressionType)
        {
            string ope = "";
            switch (expressionType)
            {
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                    ope = "+";
                    break;
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    ope = "AND";
                    break;
                case ExpressionType.ArrayLength:
                    ope = "LENGTH";
                    break;
                case ExpressionType.ArrayIndex:
                    break;
                case ExpressionType.Call:
                    break;
                case ExpressionType.Coalesce:
                    break;
                case ExpressionType.Conditional:
                    break;
                case ExpressionType.Constant:
                    break;
                case ExpressionType.Convert:
                    break;
                case ExpressionType.ConvertChecked:
                    break;
                case ExpressionType.Divide:
                    ope = "/";
                    break;
                case ExpressionType.Equal:
                    ope = "=";
                    break;
                case ExpressionType.ExclusiveOr:
                    break;
                case ExpressionType.GreaterThan:
                    ope = ">";
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    ope = ">=";
                    break;
                case ExpressionType.Invoke:
                    break;
                case ExpressionType.Lambda:
                    break;
                case ExpressionType.LeftShift:
                    break;
                case ExpressionType.LessThan:
                    ope = "<";
                    break;
                case ExpressionType.LessThanOrEqual:
                    ope = "<=";
                    break;
                case ExpressionType.ListInit:
                    break;
                case ExpressionType.MemberAccess:
                    break;
                case ExpressionType.MemberInit:
                    break;
                case ExpressionType.Modulo:
                    break;
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                    ope = "*";
                    break;
                case ExpressionType.Negate:
                    ope = "-";
                    break;
                case ExpressionType.UnaryPlus:
                    break;
                case ExpressionType.NegateChecked:
                    ope = "-";
                    break;
                case ExpressionType.New:
                    break;
                case ExpressionType.NewArrayInit:
                    break;
                case ExpressionType.NewArrayBounds:
                    break;
                case ExpressionType.Not:
                    break;
                case ExpressionType.NotEqual:
                    ope = "<>";
                    break;
                case ExpressionType.Or:
                    ope = "OR";
                    break;
                case ExpressionType.OrElse:
                    ope = "OR";
                    break;
                case ExpressionType.Parameter:
                    break;
                case ExpressionType.Power:
                    break;
                case ExpressionType.Quote:
                    break;
                case ExpressionType.RightShift:
                    break;
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                    ope = "-";
                    break;
                case ExpressionType.TypeAs:
                    break;
                case ExpressionType.TypeIs:
                    break;
                case ExpressionType.Assign:
                    break;
                case ExpressionType.Block:
                    break;
                case ExpressionType.DebugInfo:
                    break;
                case ExpressionType.Decrement:
                    break;
                case ExpressionType.Dynamic:
                    break;
                case ExpressionType.Default:
                    break;
                case ExpressionType.Extension:
                    break;
                case ExpressionType.Goto:
                    break;
                case ExpressionType.Increment:
                    break;
                case ExpressionType.Index:
                    break;
                case ExpressionType.Label:
                    break;
                case ExpressionType.RuntimeVariables:
                    break;
                case ExpressionType.Loop:
                    break;
                case ExpressionType.Switch:
                    break;
                case ExpressionType.Throw:
                    break;
                case ExpressionType.Try:
                    break;
                case ExpressionType.Unbox:
                    break;
                case ExpressionType.AddAssign:
                case ExpressionType.AndAssign:
                    ope = "+";
                    break;
                case ExpressionType.DivideAssign:
                    ope = "-";
                    break;
                case ExpressionType.ExclusiveOrAssign:
                    break;
                case ExpressionType.LeftShiftAssign:
                    break;
                case ExpressionType.ModuloAssign:
                    break;
                case ExpressionType.MultiplyAssign:
                    break;
                case ExpressionType.OrAssign:
                    break;
                case ExpressionType.PowerAssign:
                    break;
                case ExpressionType.RightShiftAssign:
                    break;
                case ExpressionType.SubtractAssign:
                    ope = "-";
                    break;
                case ExpressionType.AddAssignChecked:
                    ope = "+";
                    break;
                case ExpressionType.MultiplyAssignChecked:
                    break;
                case ExpressionType.SubtractAssignChecked:
                    break;
                case ExpressionType.PreIncrementAssign:
                    break;
                case ExpressionType.PreDecrementAssign:
                    break;
                case ExpressionType.PostIncrementAssign:
                    break;
                case ExpressionType.PostDecrementAssign:
                    break;
                case ExpressionType.TypeEqual:
                    break;
                case ExpressionType.OnesComplement:
                    break;
                case ExpressionType.IsTrue:
                    break;
                case ExpressionType.IsFalse:
                    break;
                default:
                    break;
            }
            return ope;
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T),"c");
            MyExpressionVisitor visitor = new MyExpressionVisitor(parameterExpression);

            var left = visitor.Replace(exp1.Body);
            var right = visitor.Replace(exp2.Body);

            var newBody = Expression.And(left, right);
            return Expression.Lambda<Func<T, bool>>(newBody, parameterExpression);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "a");
            MyExpressionVisitor visitor = new MyExpressionVisitor(parameterExpression);

            var left = visitor.Replace(exp1.Body);
            var right = visitor.Replace(exp2.Body);

            var newBody = Expression.Or(left, right);
            return Expression.Lambda<Func<T, bool>>(newBody, parameterExpression);
        }

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> exp)
        {
            var parmExp = exp.Parameters[0];
            var body = Expression.Not(exp.Body);
            return Expression.Lambda<Func<T, bool>>(body, parmExp);
        }
    }
}
