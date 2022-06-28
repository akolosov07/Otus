using System.Reflection;
using System.Text.Json.Serialization;

namespace Dopusteam.Otus.Reflection.ConsoleApp.Examples;

public static class AttributesExample
{
    public static void Run()
    {
        var type = typeof(AttributesItem);
        var type2 = typeof(AttributesItem2);

        // var properties = type.GetProperties(BindingFlags.NonPublic);
        Console.WriteLine(string.Join(Environment.NewLine, type.GetProperties().Select(prop => prop.Name)));
        Console.WriteLine(string.Join(Environment.NewLine, type2.GetProperties().Select(prop => prop.Name)));

        // foreach (var property in type.GetProperties())
        // {
        //     if (property.GetCustomAttributes().OfType<HiddenAttribute>().Any())
        //     {
        //         Console.WriteLine($"{property.Name}: Hidden");
        //     }
        //     else
        //     {
        //         Console.WriteLine($"{property.Name}: Visible");
        //     }
        // }
    }
}

public class AttributesItem
{
    [Hidden]
    public string HiddenProperty { get; }

    public string VisibleProperty { get; }

    public AttributesItem(string hidden, string visible)
    {
        HiddenProperty = hidden;
        VisibleProperty = visible;
    }
}

public class AttributesItem2
{
    public string VisibleProperty { get; }
    
    [Hidden]
    public string HiddenProperty { get; }

    public AttributesItem2(string hidden, string visible)
    {
        HiddenProperty = hidden;
        VisibleProperty = visible;
    }
}

public class HiddenAttribute : Attribute
{
}