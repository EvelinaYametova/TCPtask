using System;
using System.Net.NetworkInformation;
using System.Linq;

namespace TCPtask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа выводит открытые порты");
            Console.WriteLine("Введите два целых числа от 0 до 65536 через пробел(диапазон портов)");
            var ports = Console.ReadLine().Split().Select(p => double.Parse(p)).OrderBy(p => p);
            if (ports.All(p => p >= 0 && p <= 65536 && p % 1 == 0))
            {
                for (var port = ports.ToArray()[0]; port <= ports.ToArray()[ports.ToArray().Length - 1]; port++)
                {
                    if (CheckIfPortIsOpen((int)port))
                    {
                        Console.WriteLine(port);
                    }
                }
                return;
            }
            Console.WriteLine("Запустите программу заново и введите данные корректно");
        }

        static bool CheckIfPortIsOpen(int port)
        {
            return IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners().Any(l => l.Port == port);
        }
    }
}