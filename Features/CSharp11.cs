using System.Numerics;

namespace CSharpVersionsFeatures.Features
{
    public class CSharep11
    {

        /// <summary>
        ///  Parameter Null Checking This new feature is based on, as we already know, 
        ///  it is common to use variations of boilerplate code to validate if the method arguments are null,
        /// </summary>
        public static void NullCheck()
        {
            try
            {
                Inner(null);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Null check throws exception:{ex.Message}");
            }
            
            static void Inner(string name!!)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/
        /// </summary>
        public static void GenericMath()
        {
            var result = AddAll(new[] { 1, 2, 3, 4, 5 });
            
            Console.WriteLine($"Generic math sum => {result}");            
            
            static T AddAll<T>(T[] values) where T : INumber<T>
            {
                T result = T.AdditiveIdentity;
                foreach (var value in values)
                {
                    result += value;
                }
                return result;
            }
        }

        /// <summary>
        /// https://devblogs.microsoft.com/dotnet/early-peek-at-csharp-11-features/
        /// </summary>
        public static void ListPattern()
        {
            var result = AddAll(new[] { 1, 2, .3, 4, 5 });

            Console.WriteLine($"Generic list range sum => {result}");
                        
            static T AddAll<T>(T[] values) where T : INumber<T> => values switch
            {
                [] => T.AdditiveIdentity,
                [var t1, .. var middle] => t1 + AddAll(middle),
            };
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#string-literals
        /// </summary>
        public static void RawStringLiterals()
        {
            string longMessage = """
                                This is a long message.
                                It has several lines.
                                    Some are indented
                                            more than others.
                                Some should start at the first column.
                                Some have "quoted text" in them.
                                """;
            Console.WriteLine($"RawStringLiterals=> { longMessage}");

            var location = $$"""
                           You are at {{{10.23}}, {{52.23}}}
                           """;

            Console.WriteLine($"RawStringLiterals=>{location}");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void InitProp()
        {
            var person = new Person
            {
                FirstName = "Abrar"
            };
            //below line will show errro compilation time
            //person.LastName = "Ansari";
        }

    }


    //introduced c# 9.0  and c# 11.0 introduced required and field
    public class Person
    {
        public string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public string LastName { get; init; }
    }
}

