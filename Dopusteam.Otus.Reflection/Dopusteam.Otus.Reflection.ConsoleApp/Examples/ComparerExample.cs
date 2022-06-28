using Dopusteam.Otus.Reflection.Comparer;

namespace Dopusteam.Otus.Reflection.ConsoleApp.Examples;

public static class ComparerExample
{
    public static void Run()
    {
        var first = new ComparableItem("1", "FirstName", "FirstFullName");
        var second = new ComparableItem("2", "SecondName", "SecondFullName");

        var differences = ObjectsComparer.GetDifference(first, second);

        Console.WriteLine(differences);
    }
}

public class ComparableItem
{
    public string Id { get; }

    public string Name { get; }

    public string FullName { get; }

    public ComparableItem(string id, string name, string fullName)
    {
        Id = id;
        Name = name;
        FullName = fullName;
    }
}