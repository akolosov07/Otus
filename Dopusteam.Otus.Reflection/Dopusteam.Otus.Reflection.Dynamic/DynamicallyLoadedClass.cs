namespace Dopusteam.Otus.Reflection.Dynamic;

public class DynamicallyLoadedClass
{
    public string Name { get; }

    public DynamicallyLoadedClass(string name)
    {
        Name = name;
    }

    public string SayHello() => $"Hello from dynamically loaded assembly {Name}";

    public void DoSomething()
    {
        Console.WriteLine($"{Name}: {DateTime.Now}");
    }
}