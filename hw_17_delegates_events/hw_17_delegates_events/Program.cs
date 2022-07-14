using hw_17_delegates_events;

var list = new List<Employee>();
var r = new Random();
for (int i = 0; i < 10; i++)
{
    list.Add(new Employee { Name = i.ToString(), Salary = r.Next(10000) });
}

var maxItem = list.GetMax(emp => emp.Salary);
// Выводит максимум
Console.WriteLine($"Maximum Salary из list, Salary : {maxItem.Salary}, Name = {maxItem.Name} ");

FileFinder fileFinder = new FileFinder();
fileFinder.FileFound += DisplayMessage;
CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken ct = cts.Token;

var task = new Task(() =>
{
    Console.WriteLine($"Task стартовал");
    fileFinder.Find(@"C:\sites\images", ct);
}, ct);
task.Start();


Console.WriteLine("Нажмите любую клавишу для отмены");
Console.ReadKey();
cts.Cancel();
//task.Wait();
Console.ReadLine();

void DisplayMessage(object sender, FileArgs e)
{
    // Выводит сообщение
    Console.WriteLine(e.Message);
}
