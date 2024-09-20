using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class MessageClient
{
    static async Task Main()
    {
        using (var client = new TcpClient("127.0.0.1", 5000))
        using (var stream = client.GetStream())
        {
            Console.WriteLine("Подключено к серверу.");
            byte[] buffer = new byte[256];

            while (true)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Получено сообщение: {message}");
            }
        }
    }
}