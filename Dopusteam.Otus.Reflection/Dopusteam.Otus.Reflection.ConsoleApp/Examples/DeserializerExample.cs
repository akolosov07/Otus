using Dopusteam.Otus.Reflection.Converter;

namespace Dopusteam.Otus.Reflection.ConsoleApp.Examples;

public static class DeserializerExample
{
    public static void Run()
    {
        var result = Deserializer.Handle(typeof(DeserializableItem), @"{""Id"": ""12""}");

        Console.WriteLine(result);
    }
}

public class DeserializableItem
{
    public string Id { get; }

    public DeserializableItem(string id)
    {
        Id = id;
    }

    public override string ToString() => $"My id is: {Id}";
}