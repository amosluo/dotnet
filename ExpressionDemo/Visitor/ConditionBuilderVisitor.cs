using ExpressionDemo.Exd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Visitor
{
    public class ConditionBuilderVisitor : ExpressionVisitor
    {
        private Stack<string> _conditonStack = new Stack<string>();

        public string Condition()
        {
            string condition = string.Concat(_conditonStack.ToArray());
            this._conditonStack.Clear();
            return condition;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node == null) throw new Exception("Expression is null.");
            this._conditonStack.Push(")");
            Expression right = base.Visit(node.Right);
            this._conditonStack.Push(" " + node.NodeType.ToSqlOperator() + " ");
            Expression left = base.Visit(node.Left);
            this._conditonStack.Push("(");

            return node;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node == null) throw new Exception("Expression is null.");
            this._conditonStack.Push("[" + node.Member.Name + "]");
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node == null) throw new Exception("VisitConstant excetpion, Expression is null.");
            this._conditonStack.Push("'" + node.Value + "'");
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node == null) throw new Exception("VisitMethodCall excetpion, Expression is null.");
            string format = "";
            switch (node.Method.Name)
            {
                case "StartsWith":
                    format = "('{0}' LIKE {1}+'%')";
                    break;
                case "Contains":
                    format = "('{0}' LIKE '%'+{1}+'%')";
                    break;
                case "EndsWith":
                    format = "('{0}' LIKE '%'+{1})";
                    break;
                default:
                    throw new Exception($"VisitMethodCall excetpion, {node.Method} is not supported.");
            }
            this.Visit(node.Object);
            this.Visit(node.Arguments[0]);
            string right = this._conditonStack.Pop();
            string left = this._conditonStack.Pop();
            this._conditonStack.Push(string.Format(format, left, right));
            return node;
        }
    }
}
