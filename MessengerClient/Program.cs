using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class MessengerClient
{
    public static async Task Main(string[] args)
    {
        using TcpClient client = new TcpClient();
        Console.WriteLine($"Client started");

        try
        {
            var (ipAddress, port) = GetIPAndPort();
            await client.ConnectAsync(ipAddress, int.Parse(port));

            Console.WriteLine($"Client connected {ipAddress}:{port}");

            var reader = new StreamReader(client.GetStream());
            var writer = new StreamWriter(client.GetStream());

            await Task.Run(async () => ReceiveMessageAsync(reader));

            await Task.Run(async () => SendMessageAsync(writer));
        }
        catch (SocketException socketException)
        {
            Console.WriteLine("Server is not reachable");
        }
        catch (IOException ioException)
        {
            Console.WriteLine("Server disconnected");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static async Task SendMessageAsync(StreamWriter writer)
    {
        while(true)
        {
            Console.Write(">");
            var message = Console.ReadLine();
            await writer.WriteLineAsync(message);
            await writer.FlushAsync();
        }
    }

    private static async Task ReceiveMessageAsync(StreamReader reader)
    {
        while(true)
        {
            var message = await reader.ReadLineAsync();
            if (string.IsNullOrEmpty(message))
                continue;
            if (message == "DISCONNECT ACCEPTED")
            {
                Print("You have disconnected successfully");
                break;
            }
            Print(message);
        }
    }

    private static void Print(string message)
    {
        var position = Console.GetCursorPosition();
        Console.MoveBufferArea(0, position.Top, position.Left, 1, 0, position.Top + 1);
        Console.SetCursorPosition(0, position.Top);
        Console.WriteLine(message);
        Console.SetCursorPosition(position.Left, position.Top + 1);
    }

    private static (string, string) GetIPAndPort()
    {
        var config = File.ReadLines("./config.txt").ToArray()[0].Split(':');
        return (config[0], config[1]);
    }
}