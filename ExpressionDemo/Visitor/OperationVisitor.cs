using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Visitor
{
    public class OperationVisitor : ExpressionVisitor
    {
        private string expStr = "";
        public Expression Modify(Expression expression)
        {
            return this.Visit(expression);
            //return expStr;
        }

        public override Expression Visit(Expression node)
        {
            Console.WriteLine($"{node.ToString()}");
            return base.Visit(node);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if(node.NodeType == ExpressionType.Add)
            {
                expStr += "+" + node.Right;
                Expression left = this.Visit(node.Left);
                Expression right = this.Visit(node.Right);
                return Expression.Add(left, right);
            }
            else if (node.NodeType == ExpressionType.Subtract)
            {
                expStr += "-" + node.Right;
                Expression left = this.Visit(node.Left);
                Expression right = this.Visit(node.Right);
                return Expression.Subtract(left, right);
            }
            else if (node.NodeType == ExpressionType.Multiply)
            {
                expStr += "*" + node.Right;
                Expression left = this.Visit(node.Left);
                Expression right = this.Visit(node.Right);
                return Expression.Multiply(left, right);
            }
            else if (node.NodeType == ExpressionType.Divide)
            {
                expStr += "/" + node.Right;
                Expression left = this.Visit(node.Left);
                Expression right = this.Visit(node.Right);
                return Expression.Divide(left, right);
            }
            else if (node.NodeType == ExpressionType.Modulo)
            {
                Expression left = this.Visit(node.Left);
                Expression right = this.Visit(node.Right);
                return Expression.Modulo(left, right);
            }
            return base.VisitBinary(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            expStr += node.Value;
            return base.VisitConstant(node);
        }
    }
}
