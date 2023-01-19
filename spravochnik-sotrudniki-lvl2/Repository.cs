using System;
using System.Globalization;
using System.IO;
using System.Linq;
using static System.Console;

namespace ConsoleApp7
{
    class Repository
    {
        /// <summary>
        /// Массив работникав
        /// </summary>
        public Worker[] workers;

        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string path;

        /// <summary>
        /// переменная для индексов
        /// </summary>
        int index;

        /// <summary>
        /// Переменная для счета айди
        /// </summary>
        int id;

        /// <summary>
        /// Конструктор Файла
        /// </summary>
        /// <param name="Path">Путь</param>
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.workers = new Worker[2];
            this.id = 0;
        }

        #region Методы

        /// <summary>
        /// метод добавляет нового работника
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker(Worker worker)
        {
            Clear();

            id = File.ReadAllLines(this.path).Length + 1;

            using (StreamWriter sw = new StreamWriter(this.path, true))
            {


                sw.Write(id);
                string note = string.Empty;
                string now = DateTime.Now.ToString();
                WriteLine($"Время заметки {now}");
                note += $"#{now}#";
                WriteLine();
                WriteLine("Введите Ф.И.О  ");
                note += $"{ReadLine()}#";
                WriteLine();
                WriteLine("Введите возраст: ");
                note += $"{ReadLine()}#";
                WriteLine();
                WriteLine("Введите рост: ");
                note += $"{ReadLine()}#";
                WriteLine();
                WriteLine("Введите дату рождения: ");
                note += $"{ReadLine()}#";
                WriteLine();
                WriteLine("Введите место рождения: ");
                note += $"город {ReadLine()}";
                sw.WriteLine(note);

            }


        }

        /// <summary>
        /// Метод увеличивает массив в 2 раза
        /// </summary>
        /// <param name="Flag"></param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, this.workers.Length * 2);
            }
        }

        /// <summary>
        /// Метод добавляет новго работника
        /// </summary>
        /// <param name="ConcreteWorker"></param>
        public void Add(Worker ConcreteWorker)
        {
            this.Resize(index >= this.workers.Length);
            this.workers[index] = ConcreteWorker;
            this.index++;
        }

        /// <summary>
        /// Метод считывает данные с файла
        /// </summary>
        public void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    Add(new Worker(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]),
                        args[2], args[3], args[4], Convert.ToDateTime(args[5]), 
                        args[6]));
                }
            }
        }

        /// <summary>
        /// Метод выводит в коносль работников
        /// </summary>
        public void PrintDbToConsole()
        {
            Clear();
            for (int i = 0; i < index; i++)
            {
                WriteLine(this.workers[i].Print().Replace('#', ' '));
            }

        }

        /// <summary>
        /// Метод возвращате работника по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void GetWorkerById(ref Worker[] workers)
        {
            Clear();
            int userNumber = int.Parse(ReadLine());
            for (int i = 0; i < index; i++)
            {
                if (workers[i].id == userNumber)
                {
                    WriteLine(this.workers[id].Print().Replace('#', ' '));
                }
            }
        }

        /// <summary>
        /// Метод соритрует массив рабтников по диапазону дат
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public void GetWorkersBetweenTwoDates(ref Worker[] workers)
        {
            Clear();
            CultureInfo cultureInfo = new CultureInfo("RU");
            WriteLine("Введите начальный дипазон дат >>>");
            DateTime dateStart = DateTime.ParseExact(ReadLine(), "dd.MM.yyyy", cultureInfo);
            WriteLine("Введите конечный диапазон дат >>>");
            DateTime dateEnd = DateTime.ParseExact(ReadLine(), "dd.MM.yyyy", cultureInfo);

            for (int i = 0; i < index; i++)
            {
                if (workers[i].RecordingDate >= dateStart && workers[i].RecordingDate <= dateEnd)
                {
                    WriteLine($"{this.workers[i].Print().Replace('#', ' ')}");
                }
            }
        }

        /// <summary>
        /// Метод пререзаписывает файл
        /// </summary>
        public void NewFileCreate(ref Worker[] workers)
        {
            using (StreamWriter sw = new StreamWriter(this.path))
            {
                for (int i = 0; i < index; i++)
                {
                    sw.WriteLine(this.workers[i].Print());
                }
            }
        }

        /// <summary>
        /// Метод удаляет рабтника
        /// </summary>
        /// <param name="workers"></param>
        public void DeleteWorker(ref Worker[] workers)
        {
            Clear();
            for (int i = 0; i < index; i++)
            {
                WriteLine(this.workers[i].Print().Replace('#', ' '));
            }
            WriteLine("\nВведите id работика которого хотите удалить >>>");

            int userNumber = int.Parse(ReadLine());
            for (int i = 0; i < index; i++)
            {
                if (userNumber == workers[i].id)
                {
                    Array.Clear(workers, userNumber - 1, 1);
                    NewFileCreate(ref this.workers);
                }
            }
            for (int i = 0; i < index; i++)
            {
                WriteLine(this.workers[i].Print().Replace('#', ' '));
            }
            WriteLine("\nВы удалили работника, файл перезаписан");
        }

        /// <summary>
        /// Метод сортирует работников по полям
        /// </summary>
        public void SortWorkers(ref Worker[] ConcreteWorker)
        {
            Clear();
            Write("Ведите номер по которому хотите отсортировать работников в Алфавитном порядке" +
                "\n1 - сортировать по Айди \n2 - сортировать по дате записи работника \n3 - сортировать по Фио" +
                "\n4 - сортировать по Возрасту \n5 - сортировать по Росту \n6 - сортировать по Дате рождения \n7 - сортировать по Месту рождения" +
                "\nВведите номер >>> ");
            string userNumber = ReadLine();
            switch (userNumber)
            {
                case "1":
                    var id = workers.OrderBy(workers => workers.id);
                    foreach (var item in id) if (item.id != 0) WriteLine(item.Print().Replace('#', ' ')); break;
                case "2":
                    var recordingDate = workers.OrderBy(workers => workers.RecordingDate);
                    foreach (var item in recordingDate) if (item.id != 0) WriteLine(item.Print().Replace('#', ' ')); break;
                case "3":
                    var Fio = workers.OrderBy(workers => workers.Fio);
                    foreach (var item in Fio) if (item.id != 0) WriteLine(item.Print().Replace('#', ' ')); break;
                case "4":
                    var Age = workers.OrderBy(workers => workers.Age);
                    foreach (var item in Age) if (item.id != 0) WriteLine(item.Print().Replace('#', ' ')); break;
                case "5":
                    var Growth = workers.OrderBy(workers => workers.Growth);
                    foreach (var item in Growth) if (item.id != 0) WriteLine(item.Print().Replace('#', ' ')); break;
                case "6":
                    var DateOfBirth = workers.OrderBy(workers => workers.DateOfBirth);
                    foreach (var item in DateOfBirth) if (item.id != 0) WriteLine(item.Print().Replace('#', ' ')); break;
                case "7":
                    var PlaceOfBirth = workers.OrderBy(workers => workers.PlaceOfBirth);
                    foreach (var item in PlaceOfBirth) if (item.id != 0) WriteLine(item.Print().Replace('#', ' ')); break;
            }
        }


        /// <summary>
        /// Количество сотрудников
        /// </summary>
        public int Count { get { return this.index; } }


        #endregion
    }
}
