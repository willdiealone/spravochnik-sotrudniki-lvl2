using System.IO;
using static System.Console;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = "/Users/lilrockstar/Desktop/text.txt";
            
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            fileStream.Close();

            Repository rp = new Repository(path);


            Write("1 - вывод работникаов в консоль \n2 - добавить нового работника" +
                "\n3 - удалить работника \n4 - вернуть работника по айди \n5 - отсортировать работников по полям" +
                "\n6 - отсортировать работиков по датам \nВведите номер >>> ");
            string UserNumber = ReadLine();

            switch (UserNumber)
            {
                case "1": rp.Load(); rp.PrintDbToConsole(); WriteLine($"Сотрудников: {rp.Count}"); break;
                case "2": rp.AddWorker(new Worker()); break;
                case "3": rp.Load(); rp.DeleteWorker(ref rp.workers); break;
                case "4": rp.Load(); rp.GetWorkerById(ref rp.workers); break;
                case "5": rp.Load(); rp.SortWorkers(ref rp.workers); break;
                case "6": rp.Load(); rp.GetWorkersBetweenTwoDates(ref rp.workers); break;
            }
            ReadKey();



        }
    }
}
