namespace hw_17_delegates_events
{
    // 3. Оформить событие и его аргументы с использованием .NET соглашений:
    // public event EventHandler FileFound; FileArgs – будет содержать имя файла и наследоваться от EventArgs
    public class FileArgs : EventArgs
    {
        public string Message { get; set; }
        public string FileName { get; set; }

        public FileArgs(string message, string fileName)
        {
            Message = message;
            FileName = fileName;
        }
    }

    /// <summary>
    /// 2. Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
    /// </summary>
    public class FileFinder
    {
        public event EventHandler<FileArgs> FileFound;

        public void Find(string path, CancellationToken ct)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                if (ct.IsCancellationRequested) // 4. Добавить возможность отмены дальнейшего поиска из обработчика;
                {
                    Console.WriteLine("Отмена");
                    break;
                }

                FileFound?.Invoke(this, new FileArgs($"Найден файл: {file}", file));
            }
        }
    }
}
