namespace SolidExample
{
    /// <summary>
    /// Принцип разделения интерфейса -
    /// несколько интерфейсов вместо одного
    /// </summary>
    public interface IGame
    {
        void Play();
    }

    /// <summary>
    /// Принцип разделения интерфейса -
    /// несколько интерфейсов вместо одного
    /// </summary>
    public interface IGameResults
    {
        void ShowResults();
    }

    /// <summary>
    /// Открыто для расширения 
    /// - принцип открытости и закрытости
    /// </summary>
    public abstract class FindNumerGame : IGame
    {
        public virtual void Play()
        { }
    }

    /// <summary>
    /// Расширяемый класс
    /// - принцип открытости и закрытости,
    /// реализуем поиск среди диапазона 1 - 100
    /// </summary>
    public class FindFrom100Number : FindNumerGame, IGameResults
    {
        private int _maxErrorNumber = 1;
        private int _errorCounter = -1;
        private bool _win = false;
        public override void Play()
        {
            var questedNumber = new Random().Next(1, 100);
            
            Console.WriteLine("Угадайте число одно из ста");
            Console.WriteLine("Задайте число попыток");
            _maxErrorNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Какое число я загадал?");

            while (true)
            {
                _errorCounter++;
                if (_errorCounter > _maxErrorNumber) break;
                int answer = Convert.ToInt32(Console.ReadLine());
                if(answer == questedNumber)
                {
                    Console.WriteLine("Правильно!");
                    _win = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Не правильно");
                    if(questedNumber > answer)
                    {
                        Console.WriteLine("Число больше");
                    }
                    else
                    {
                        Console.WriteLine("Число меньше");
                    }
                }
            }
            ShowResults();
        }

        public void ShowResults()
        {
            Console.WriteLine("Игра закончена");
            if (_win) Console.WriteLine("Вы выиграли!");
            else Console.WriteLine("Вы проиграли");
            Console.WriteLine($"Количество попыток - {_errorCounter}");
        }
    }

    /// <summary>
    /// реализуем поиск среди диапазона 1 - 10000
    /// </summary>
    public class FindFrom10000Number : FindNumerGame, IGameResults
    {
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public void ShowResults()
        {
            throw new NotImplementedException();
        }
    }
}
