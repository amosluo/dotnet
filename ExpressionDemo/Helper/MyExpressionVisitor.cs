using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Helper
{
    public class MyExpressionVisitor : ExpressionVisitor
    {
        private ParameterExpression _parameterExpression;

        public MyExpressionVisitor(ParameterExpression parameterExpression)
        {
            _parameterExpression = parameterExpression;
        }

        public Expression Replace(Expression exp)
        {
            return this.Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression parameterExpression)
        {
            return this._parameterExpression;
        }

    }
}
