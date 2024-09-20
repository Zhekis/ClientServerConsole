using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class MessageServer
{
    static async Task Main()
    {
        var listener = new TcpListener(IPAddress.Any, 5000);
        listener.Start();
        Console.WriteLine("Сервер запущен. Ожидание подключения...");

        while (true)
        {
            var client = await listener.AcceptTcpClientAsync();
            HandleClientAsync(client);
            Console.WriteLine("Клиент подключен.");
        }
    }

    private static async void HandleClientAsync(TcpClient client)
    {
        try
        {
            using (var stream = client.GetStream())
            {
                while (true)
                {
                    string message = GetMessageBasedOnDateTime();
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length);
                    await Task.Delay(1000);
                    Console.WriteLine("Сообщение отправлено: " + message);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке клиента: {ex.Message}");
        }
        finally
        {
            client.Close();
        }
    }

    private static string GetMessageBasedOnDateTime()
    {
        DateTime now = DateTime.Now;
        int evenCount = 0;
        int oddCount = 0;

        foreach (char digit in now.ToString("yyyyMMddHHmmss"))
        {
            if (digit % 2 == 0)
                evenCount++;
            else
                oddCount++;
        }

        if (evenCount > oddCount)
            return "чет!";
        else if (oddCount > evenCount)
            return "нечет!";
        else
            return "равно!";
    }
}
