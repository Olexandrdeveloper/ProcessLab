using System.Diagnostics;

namespace ProcessLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                try
                {
                    Console.WriteLine($"ID: {process.Id, -5} | Назва: {process.ProcessName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка доступу до процесу: {ex.Message}");
                }
            }
        }
    }
}
