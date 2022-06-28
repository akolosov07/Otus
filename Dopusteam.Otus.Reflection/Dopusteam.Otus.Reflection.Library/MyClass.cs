namespace Dopusteam.Otus.Reflection.Library;

public delegate void Notify(string name);

public class MyClass
{
    public readonly int Id;

    public string Name { get; private set; }

    public MyClass(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void Update(string name)
    {
        Name = name;
        Updated?.Invoke(name);
    }

    public event Notify? Updated;
}