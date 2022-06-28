namespace Dopusteam.Otus.Reflection.ConsoleApp.Examples;

public static class StringReflection
{
    public static void Run()
    {
        var stringType = typeof(string);

        var hello = "hello";

        Console.WriteLine(stringType.Name);
        Console.WriteLine(stringType.Assembly.FullName);

        Console.WriteLine("Fields:");
        var stringFields = stringType.GetFields();

        foreach (var stringField in stringFields)
        {
            Console.WriteLine(stringField.Name);
        }

        Console.WriteLine("Properties:");
        var stringProperties = stringType.GetProperties();

        foreach (var stringProperty in stringProperties)
        {
            Console.WriteLine(stringProperty.Name);
        }

        Console.WriteLine("Methods:");
        var stringMethods = stringType.GetMethods();

        foreach (var stringMethod in stringMethods)
        {
            Console.WriteLine(stringMethod.Name);
        }

        Console.WriteLine("Constructors:");
        var stringConstructors = stringType.GetConstructors();

        foreach (var stringConstructor in stringConstructors)
        {
            Console.WriteLine(stringConstructor.Name);

            foreach (var parameter in stringConstructor.GetParameters())
            {
                Console.WriteLine(parameter.Name);
            }
        }

        Console.WriteLine("Events:");
        var stringEvents = stringType.GetEvents();

        foreach (var stringEvent in stringEvents)
        {
            Console.WriteLine(stringEvent.Name);
        }

        // https://stackoverflow.com/questions/41468722/loop-reflect-through-all-properties-in-all-ef-models-to-set-column-type
    }
}