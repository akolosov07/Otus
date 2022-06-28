using OtusCsvSerializer;

// 2. Проверить на классе: class F { int i1, i2, i3, i4, i5; Get()
// => new F(){ i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 }; }
TestSerializerHelper.TestSingleFclassSerialize(); // output 1,2,3,4,5

var list = new List<F>();
for (int i = 0; i < 100000; i++)
{
    F f = new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
    list.Add(f);
}

Console.WriteLine($"Количество тестируемых объектов в сериализации: " + list.Count);

// 3. Замерить время до и после вызова функции
// (для большей точности можно сериализацию сделать в цикле 100-100000 раз)
var csvSerializedString = TestSerializerHelper.GetSerializedObjectsString(list);

// 7. Провести сериализацию с помощью каких-нибудь стандартных механизмов (например в JSON)
// 8. И тоже посчитать время и прислать результат сравнения
var sysTextJsonString = TestSerializerHelper.GetSysTextJsonSerializedString(list);
TestSerializerHelper.GetSysTextJsonSerializedString(sysTextJsonString);

// 9. Написать десериализацию/загрузку данных из строки (ini/csv-файла) в экземпляр любого класса
// 10. Замерить время на десериализацию
TestSerializerHelper.CustomCsvDeserialize(csvSerializedString);


// 11. Общий результат прислать в чат с преподавателем в системе в таком виде:
// Сериализуемый класс: class F { int i1, i2, i3, i4, i5;}
// код сериализации-десериализации: ...
// количество замеров: 1000 итераций
// мой рефлекшен:
// Время на сериализацию = 100 мс Время на десериализацию = 100 мс стандартный механизм (NewtonsoftJson):
// Время на сериализацию = 100 мс Время на десериализацию = 100 мс

/*
Сериализуемый класс:
public class F
    {
        public int i1 { get; set; }
        public int i2 { get; set; }
        public int i3 { get; set; }
        public int i4 { get; set; }
        public int i5 { get; set; }
    }
код сериализации-десериализации:


кол-во тестируемых объектов: 100000

мой рефлекшен (кастомный csv сериализация/десериализация):
Время на сериализацию = 238 мс
Время на десериализацию = 652 мс

System.Text.Json сериализация/десериализация JSON:
Время на сериализацию = 238 мс
Время на десериализацию = 652 мс

*/