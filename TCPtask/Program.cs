using System;
using System.Net.Sockets;
using System.Linq;

namespace TCPtask
{
    class Program
    {
        static string IPAddress = "127.0.0.1";
        static void Main(string[] args)
        {
            Console.WriteLine("Программа выводит открытые порты");
            Console.WriteLine("Введите IP адрес");
            IPAddress = Console.ReadLine();
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
            try
            {
                using (var tcpClient = new TcpClient())
                {
                    tcpClient.Connect(IPAddress, port);
                    return true;
                }
            }
            catch (SocketException)
            {
                return false;
            }
        }
    }
}