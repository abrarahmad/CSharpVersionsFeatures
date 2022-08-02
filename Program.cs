// See https://aka.ms/new-console-template for more information


//C# 8.0

using System.Reflection;
using CSharpVersionsFeatures.Features;

//C# 11.0
CallFeatureFunctions(typeof(CSharep11));

//C# 8.0

CallFeatureFunctions(typeof(CSharp8));



static void CallFeatureFunctions(Type? type)
{
    if (type is not null)
    {
        var methods = ((TypeInfo)type).DeclaredMethods;
        foreach (var method in methods.Where(w=>w.IsPublic))
        {
            method.Invoke(null, null);
        }
    }
}
