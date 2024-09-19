using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        const int port = 5000;
        var listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine("Сервер запущен. Ожидание подключения к клиенту...");

        while (true)
        {
            using var client = listener.AcceptTcpClient();
            Console.WriteLine("Клиент подключен.");
            NetworkStream stream = client.GetStream();

            string message = GetMessageBasedOnTime();
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Сообщение отправлено: " + message);
        }
    }

    static string GetMessageBasedOnTime()
    {
        DateTime now = DateTime.Now;
        string date = now.ToString("yyyyMMddHHmmss");
        int evenCount = 0;
        int oddCount = 0;

        foreach (char ch in now.ToString("yyyyMMddHHmmss"))
        {
            if (int.TryParse(ch.ToString(), out int number))
            {
                if (number % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
            }
        }

        if (evenCount > oddCount) return "чет!" + date;
        else if (oddCount > evenCount) return "нечет!" + date;
        else return "равно!" + date;
    }
}
