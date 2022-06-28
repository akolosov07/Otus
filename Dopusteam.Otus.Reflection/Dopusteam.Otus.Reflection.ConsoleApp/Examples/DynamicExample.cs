using System.Dynamic;

namespace Dopusteam.Otus.Reflection.ConsoleApp.Examples;

public static class DynamicExample
{
    public static void Run()
    {
        dynamic testClass1 = new TestClass();
        var testClass2 = new TestClass();
        object testClass3 = new TestClass();
        TestClass testClass4 = new TestClass();

        Console.WriteLine($"dynamic: {testClass1.GetType().Name}");
        Console.WriteLine($"var: {testClass2.GetType().Name}");
        Console.WriteLine($"object: {testClass3.GetType().Name}");
        Console.WriteLine($"TestClass: {testClass4.GetType().Name}");

        #region Expando

        dynamic expandoObject = new ExpandoObject();

        expandoObject.Set = 12;
        expandoObject.SayHello = (Action)(() => Console.WriteLine("Hello"));

        Console.WriteLine($"expando: {expandoObject.Set}");
        expandoObject.SayHello();

        #endregion
    }
}

public class TestClass
{
}