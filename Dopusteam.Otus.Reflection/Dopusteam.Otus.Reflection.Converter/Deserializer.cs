using System.Text.Json.Nodes;

namespace Dopusteam.Otus.Reflection.Converter;

public static class Deserializer
{
    public static object Handle(Type targetType, string value)
    {
        return HandleInternal(targetType, value);
    }

    private static object HandleInternal(Type targetType, string value)
    {
        var json = JsonNode.Parse(value);

        if (json is null)
        {
            throw new Exception();
        }

        var constructor = targetType.GetConstructors().First();

        var constructorParameter = constructor.GetParameters().First();

        var constructorValue = json[constructorParameter.Name!.Capitalize()]!.ToString();

        return Activator.CreateInstance(targetType, constructorValue)!;
    }
}

public static class StringExtensions
{
    public static string Capitalize(this string value)
    {
        return $"{char.ToUpper(value[0])}{value[1..]}";
    }
}