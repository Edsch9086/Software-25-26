using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static readonly IPAddress ip = IPAddress.Parse("127.0.0.1");
    const int port = 1025;

    static void Main()
    {
        TcpListener server = new TcpListener(ip, port);

        try
        {
            server.Start();
            Console.WriteLine($"[Server] Listening on {ip}:{port}...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Task.Run(() => HandleClient(client));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Error] {ex.Message}");
        }
        finally
        {
            server.Stop();
        }
    }

    static void HandleClient(TcpClient client)
    {
        IPEndPoint remoteEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
        string clientInfo = remoteEndPoint != null ? remoteEndPoint.ToString() : "Unknown";

        Console.WriteLine($"[Client Connected] {clientInfo}");

        using NetworkStream stream = client.GetStream();
        using StreamReader reader = new StreamReader(stream, Encoding.UTF8);
        using StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

        try
        {
            writer.WriteLine($"[Server] Connected to debug server at {ip}:{port}");

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string debugMsg = $"[Received from {clientInfo}] {line}";
                Console.WriteLine(debugMsg);
                writer.WriteLine($"[Echo] {line}");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"[IO Error] {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Unhandled Error] {ex.Message}");
        }
        finally
        {
            Console.WriteLine($"[Client Disconnected] {clientInfo}");
            client.Close();
        }
    }
}
