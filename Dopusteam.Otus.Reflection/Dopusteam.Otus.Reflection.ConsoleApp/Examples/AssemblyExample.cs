using System.Reflection;

namespace Dopusteam.Otus.Reflection.ConsoleApp.Examples;

public static class AssemblyExample
{
    public static void Run()
    {
        while (true)
        {
            try
            {
                var assembly = Assembly.LoadFile(@"D:\src\Dopusteam.Otus.Reflection\Dopusteam.Otus.Reflection.Dynamic\bin\Debug\net6.0\Dopusteam.Otus.Reflection.Dynamic.dll");
                Console.WriteLine($"Assembly loaded {assembly}");

                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    if (type.FullName?.Contains("DynamicallyLoadedClass") != true)
                    {
                        continue;
                    }

                    var instance = Activator.CreateInstance(type, "CustomId");

                    if (instance is null)
                    {
                        return;
                    }

                    var sayHelloMethod = type.GetMethod("SayHello");

                    if (sayHelloMethod is null)
                    {
                        Console.WriteLine("Method not found");
                        break;
                    }

                    var result = sayHelloMethod.Invoke(instance, Array.Empty<object>());

                    Console.WriteLine(result);

                    var doSomethingMethod = type.GetMethod("DoSomething");

                    doSomethingMethod?.Invoke(instance, Array.Empty<object>());
                }

                break;
            }
            catch (FileNotFoundException _)
            {
                Console.WriteLine("Assembly not found");
                Thread.Sleep(1000);
            }
        }
    }
}