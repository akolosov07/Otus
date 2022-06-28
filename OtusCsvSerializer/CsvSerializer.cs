using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace OtusCsvSerializer
{
    /// <summary>
    /// Класс сериализатор
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CsvSerializer<T> where T : class, new()
    {
        private bool _ignoreEmptyLines = true;
        private char _separator = ',';
        private List<PropertyInfo> _properties;
        private string _newlineReplacement = ((char)0x254).ToString();
        private string _replacement = ((char)0x255).ToString();
        private bool _useTextQualifier = false;

        public bool IgnoreEmptyLines
        {
            get { return _ignoreEmptyLines; }
            set { _ignoreEmptyLines = value; }
        }

        public char Separator
        {
            get { return _separator; }
            set { _separator = value; }
        }

        public string NewlineReplacement
        {
            get { return _newlineReplacement; }
            set { _newlineReplacement = value; }
        }

        public string Replacement
        {
            get { return _replacement; }
            set { _replacement = value; }
        }

        public bool UseTextQualifier
        {
            get { return _useTextQualifier; }
            set { _useTextQualifier = value; }
        }

        /// <summary>
        /// ctor
        /// </summary>
        public CsvSerializer()
        {
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance
                | BindingFlags.GetProperty | BindingFlags.SetProperty);
            _properties = properties.ToList();
        }
        /// <summary>
        /// 1. Написать сериализацию свойств или полей класса в строку
        /// Сериализация массивов класса T в строку
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Serialize(IList<T> data)
        {
            var sb = new StringBuilder();
            var values = new List<string>();

            foreach (var item in data)
            {
                values.Clear();

                foreach (var p in _properties)
                {
                    var raw = p.GetValue(item);
                    var value = raw == null ? "" :
                        raw.ToString()
                        .Replace(Separator.ToString(), Replacement)
                        .Replace(Environment.NewLine, NewlineReplacement);
                    if (UseTextQualifier)
                    {
                        value = string.Format("\"{0}\"", value);
                    }
                    values.Add(value);
                }
                sb.AppendLine(string.Join(Separator.ToString(), values.ToArray()));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 9. Написать десериализацию/загрузку данных из строки (ini/csv-файла) в экземпляр любого класса
        /// </summary>
        /// <param name="csvListObjectsString"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCsvFormatException"></exception>
        public IList<T> Deserialize(string csvListObjectsString)
        {
            string[] rows;
            try
            {
                rows = csvListObjectsString.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            }
            catch (Exception ex)
            {
                throw new InvalidCsvFormatException("Неверный csv файл.", ex);
            }

            var data = new List<T>();
            for (int row = 0; row < rows.Length; row++)
            {
                var line = rows[row];
                if (IgnoreEmptyLines && string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                else if (!IgnoreEmptyLines && string.IsNullOrWhiteSpace(line))
                {
                    throw new InvalidCsvFormatException($"Ошибка: Пустая строка под номером: {row}");
                }

                string[] parts;
                try
                {
                    parts = line.Split(Separator);
                }
                catch (Exception ex)
                {
                    throw new InvalidCsvFormatException($"Ошибка при парсинге csv файла, " +
                        $"сторока # {row}.", ex);
                }

                var datum = new T();
                
                var start = 0;
                for (int i = start; i < parts.Length; i++)
                {
                    var value = parts[i];

                    value = value
                        .Replace(Replacement, Separator.ToString())
                        .Replace(NewlineReplacement, Environment.NewLine).Trim();
                    
                    var property = _properties[i];

                    if (UseTextQualifier)
                    {
                        if (value.IndexOf("\"") == 0)
                            value = value.Substring(1);

                        if (value[value.Length - 1].ToString() == "\"")
                            value = value.Substring(0, value.Length - 1);
                    }

                    var converter = TypeDescriptor.GetConverter(property.PropertyType);
                    var convertedvalue = converter.ConvertFrom(value);

                    property.SetValue(datum, convertedvalue);
                }
                data.Add(datum);
            }
            return data;
        }
    }

    public class InvalidCsvFormatException : Exception
    {
        public InvalidCsvFormatException(string message)
            : base(message)
        {
        }

        public InvalidCsvFormatException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
