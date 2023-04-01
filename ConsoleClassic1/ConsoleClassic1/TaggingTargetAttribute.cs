using System.Reflection;

namespace ConsoleClassic1
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true,Inherited = false)]
    public class TaggingTargetAttribute : Attribute
    {
        public MethodInfo M { get; set; }

        public override string ToString() => $"TAG: {(M?.ToString() ?? base.ToString())}";

        public override object TypeId => this; 
    }
}
