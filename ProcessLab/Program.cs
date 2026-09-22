using System.Diagnostics;

namespace ProcessLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1 - Вивести список всіх активних процесів\n" +
                          "2 - Вивести інформацію про процес за ID\n" +
                          "> ");
            byte choice = byte.Parse(Console.ReadLine() ?? "1");

            if (choice == 1)
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    try
                    {
                        Console.WriteLine($"ID: {process.Id,-5} | Назва: {process.ProcessName}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка доступу до процесу: {ex.Message}");
                    }
                }
            }
            else if (choice == 2)
            {
                Console.Write("Введіть ID процесу: ");
                int processId = int.Parse(Console.ReadLine() ?? "0");

                try
                {
                    Process process = Process.GetProcessById(processId);

                    Console.WriteLine($"Потоки процесу {process.ProcessName}:");
                    foreach (ProcessThread thread in process.Threads)
                        Console.WriteLine($"ID: {thread.Id} | Пріоритет: {thread.PriorityLevel} | Час запуску: {thread.StartTime}");

                    Console.WriteLine($"\nМодулі процесу {process.ProcessName}:");
                    foreach (ProcessModule module in process.Modules)
                        Console.WriteLine($"Назва: {module.ModuleName} | Шлях: {module.FileName}");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Процес з таким ID не знайдено.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Невірний вибір");
            }
        }
    }
}
