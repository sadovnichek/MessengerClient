using System.Net.Sockets;

public enum State
{
    None,
    Connected,
    Joined
}

public class Client
{
    public StreamReader Reader { get; private set; }

    public StreamWriter Writer { get; private set; }

    private TcpClient client;

    public async Task ConnectAsync(string ipAddress, int port)
    {
        client = new TcpClient();
        await client.ConnectAsync(ipAddress, port);
        Reader = new StreamReader(client.GetStream());
        Writer = new StreamWriter(client.GetStream());
    }
}