namespace ConsoleClassic1
{
    [TaggingTarget]
    public class TargetOfStuff
    {
        [TaggingTarget]
        [TaggingTarget]
        public object TargetMethod() => 0;

        public static object StaticTargetMethod() => 0;
    }
}
