using System.Diagnostics;
using System.Text.Json;

namespace OtusCsvSerializer
{
    public class TestSerializerHelper
    {
        /// <summary>
        /// 2. Проверить на классе: class F { int i1, i2, i3, i4, i5; Get() 
        /// => new F(){ i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 }; }
        /// </summary>
        public static void TestSingleFclassSerialize()
        {
            F f = new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };

            CsvSerializer<F> csvSerializer = new CsvSerializer<F>();
            var list = new List<F>();
            list.Add(f);
            var result = csvSerializer.Serialize(list);
            Console.WriteLine(result);
        }

        /// <summary>
        /// 3. Замерить время до и после вызова функции
        /// (для большей точности можно сериализацию сделать в цикле 100-100000 раз)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GetSerializedObjectsString(IList<F> list)
        {
            CsvSerializer<F> csvSerializer = new CsvSerializer<F>();
            
            var timer = new Stopwatch();
            timer.Start();
            var serializedString = csvSerializer.Serialize(list);
            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            // 4. Вывести в консоль полученную строку и разницу времен
            Console.WriteLine("Времени заняло (кастомная сериализация csv): " + timeTaken.ToString(@"m\:ss\.fff"));
            return serializedString;
        }

        /// <summary>
        /// 7. Провести сериализацию с помощью каких-нибудь стандартных механизмов (например в JSON)
        /// 8. И тоже посчитать время и прислать результат сравнения
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GetSysTextJsonSerializedString(IList<F> list)
        {
            var timer = new Stopwatch();
            timer.Start();
            var jsonString = JsonSerializer.Serialize(list);
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine("Времени заняло на сериализацию JSON (библиотека System.Text.Json): " 
                + timeTaken.ToString(@"m\:ss\.fff"));
            return jsonString;
        }

        /// <summary>
        /// Десериализация System.Text.Json
        /// </summary>
        /// <param name="sysTextJsonString"></param>
        public static void GetSysTextJsonSerializedString(string sysTextJsonString)
        {
            var timer = new Stopwatch();
            timer.Start();
            var list = JsonSerializer.Deserialize<List<F>>(sysTextJsonString);
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine("Времени заняло на десериализацию JSON (библиотека System.Text.Json): "
                + timeTaken.ToString(@"m\:ss\.fff"));
        }

        /// <summary>
        /// 9. Написать десериализацию/загрузку данных из строки (ini/csv-файла) в экземпляр любого класса
        /// 10. Замерить время на десериализацию
        /// </summary>
        /// <param name="csvSerializedString"></param>
        public static void CustomCsvDeserialize(string csvSerializedString)
        {
            CsvSerializer<F> csvSerializer = new CsvSerializer<F>();

            var timer = new Stopwatch();
            timer.Start();
            var list = csvSerializer.Deserialize(csvSerializedString);
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine("Времени заняло на десериализацию (кастомная десериализация csv): "
                + timeTaken.ToString(@"m\:ss\.fff"));
        }
    }
}
