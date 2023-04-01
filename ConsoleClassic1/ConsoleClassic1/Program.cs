using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace ConsoleClassic1
{


    // https://stackoverflow.com/questions/12143650/how-to-add-property-level-attribute-to-the-typedescriptor-at-runtime
    // https://stackoverflow.com/questions/34509662/iextenderprovider-add-just-some-properties-depending-on-object-type/34511085#34511085
    public class Program
    {
        public static void Main(string[] args)
        {
        }


        public static void AssemblyTest(string[] args)
        {
            // https://docs.microsoft.com/en-us/dotnet/core/dependency-loading/understanding-assemblyloadcontext
            // https://jonathancrozier.com/blog/how-to-dynamically-load-different-versions-of-an-assembly-in-the-same-dot-net-application
            //AssemblyLoadContext.

        }

        public static void AttributeTest(string[] args)
        {
            {
                var mi2 = RefExt.GetMethod<TargetOfStuff>(e => e.TargetMethod());
                var mi3 = RefExt.GetMethod(() => TargetOfStuff.StaticTargetMethod());

                var target = mi2; // typeof(TargetOfStuff);

                {
                    var attributes = target.GetCustomAttributes().Concat(TypeDescriptor.GetAttributes(target).OfType<Attribute>());

                    Console.WriteLine("-- Check Attributes");
                    if (!attributes.Any())
                    {
                        Console.WriteLine("===> No Attributes");
                    }
                    foreach (var attribute in attributes)
                    {
                        Console.WriteLine($"===> {attribute}");
                    }
                }

                TypeDescriptor.AddAttributes(target, new TaggingTargetAttribute() { M = mi3 });
                TypeDescriptor.AddAttributes(target, new TaggingTargetAttribute() { M = mi2 });

                {
                    var attributes = target.GetCustomAttributes().Concat(TypeDescriptor.GetAttributes(target).OfType<Attribute>());

                    Console.WriteLine("-- Check Attributes 2");
                    if (!attributes.Any())
                    {
                        Console.WriteLine("===> No Attributes");
                    }
                    foreach (var attribute in attributes)
                    {
                        Console.WriteLine($"===> {attribute}");
                    }
                }

            }
            {
                var target = RefExt.GetMethod<TargetOfStuff>(e => e.TargetMethod());


                {
                    var attributes = target.GetCustomAttributes().Concat(TypeDescriptor.GetAttributes(target).OfType<Attribute>());

                    Console.WriteLine("-- Check Attributes 3");
                    if (!attributes.Any())
                    {
                        Console.WriteLine("===> No Attributes");
                    }
                    foreach (var attribute in attributes)
                    {
                        Console.WriteLine($"===> {attribute}");
                    }
                }
            }

        }
    }
}
