using System;
using System.Linq.Expressions;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Extensions
{
    internal static class ExpressionExtensions
    {
        internal static Expression<Func<T, bool>> Combine<T>(this Expression<Func<T, bool>> target, Expression<Func<T, bool>> expression)
        {
            if (target == null && expression == null) throw new ArgumentException("At least one argument must not be null");

            if (target == null) return expression;

            if (expression == null) return target;

            var parameter = Expression.Parameter(typeof(T), "p");

            var combined = new ParameterReplacer(parameter).Visit(Expression.OrElse(target.Body, expression.Body));

            return Expression.Lambda<Func<T, bool>>(combined, parameter);
        }

        private class ParameterReplacer : ExpressionVisitor
        {
            readonly ParameterExpression parameter;

            internal ParameterReplacer(ParameterExpression parameter)
            {
                this.parameter = parameter;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return parameter;
            }
        }
    }
}
