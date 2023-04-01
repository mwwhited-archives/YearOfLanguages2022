using System.Linq.Expressions;
using System.Reflection;

namespace ConsoleClassic1
{
    public static class RefExt
    {
        public static MethodInfo? GetMethod<T>(Expression<Action<T>> exp) =>
            (exp.Body as MethodCallExpression)?.Method;

        public static MethodInfo? GetMethod(Expression<Action> exp) =>
            (exp.Body as MethodCallExpression)?.Method;
    }
}
