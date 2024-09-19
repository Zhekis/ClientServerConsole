using System.Net.Sockets;
using System.Text;

namespace MessageClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string serverIp = "127.0.0.1";
            const int port = 5000;

            using var client = new TcpClient(serverIp, port);
            NetworkStream stream = client.GetStream();

            byte[] data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            string response = Encoding.UTF8.GetString(data, 0, bytes);

            Console.WriteLine("Сообщение от сервера: " + response);
        }
    }
}