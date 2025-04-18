using System.Windows.Forms;

namespace MessengerUI
{
    public partial class BaseForm : Form
    {
        private string ipAddress;
        private string port;
        private Client client;

        public BaseForm()
        {
            InitializeComponent();
            (ipAddress, port) = GetIPAndPort();
            client = new Client();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Run(async () => await client.ConnectAsync(ipAddress, int.Parse(port)))
                    .ContinueWith(result =>
                    {
                        if(!result.IsFaulted)
                        {
                            connectToolStripMenuItem.Enabled = false;
                            joinToolStripMenuItem.Enabled = true;
                            disconnectToolStripMenuItem.Enabled = true;
                            setNameToolStripMenuItem.Enabled = true;
                            createRoomToolStripMenuItem.Enabled = true;
                            MessageBox.Show("Connected");
                            Task.Run(async () => await ReceiveMessageAsync(client));
                        }
                        else
                        {
                            MessageBox.Show("Server is unavailable");
                        }
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcessDisconnect()
        {
            disconnectToolStripMenuItem.Enabled = false;
            connectToolStripMenuItem.Enabled = true;
            joinToolStripMenuItem.Enabled = false;
            setNameToolStripMenuItem.Enabled = false;
            createRoomToolStripMenuItem.Enabled = false;
            sendButton.Invoke(new Action(() => sendButton.Enabled = false));
            onlineUsers.Invoke(new Action(onlineUsers.Items.Clear));
            chat.Invoke(new Action(chat.Clear));
            textField.Invoke(new Action(textField.Clear));
        }

        private void ProcessQuit()
        {
            joinToolStripMenuItem.Enabled = true;
            leaveRoomToolStripMenuItem.Enabled = false;
            sendButton.Invoke(new Action(() => sendButton.Enabled = false));
            onlineUsers.Invoke(new Action(onlineUsers.Items.Clear));
            chat.Invoke(new Action(chat.Clear));
            textField.Invoke(new Action(textField.Clear));
        }

        private void ProcessOnline(string message)
        {
            onlineUsers.Invoke(() =>
            {
                onlineUsers.Items.Clear();
                message.Split()[1].Split(';').ToList().ForEach(p => onlineUsers.Items.Add(p));
            });
        }

        private async Task ReceiveMessageAsync(Client client)
        {
            while (true)
            {
                var message = await client.Reader.ReadLineAsync();
                if (string.IsNullOrEmpty(message))
                    continue;
                if (message.StartsWith("DISCONNECT ACCEPTED"))
                {
                    ProcessDisconnect();
                    break;
                }
                else if (message.StartsWith("NAME ACCEPTED"))
                {
                    MessageBox.Show(message);
                }
                else if (message.StartsWith("QUIT ACCEPTED"))
                {
                    ProcessQuit();
                }
                else if(message.StartsWith("ONLINE"))
                {
                    ProcessOnline(message);
                }
                else if (message.StartsWith("JOIN ACCEPTED"))
                {
                    joinToolStripMenuItem.Enabled = false;
                    leaveRoomToolStripMenuItem.Enabled = true;
                    sendButton.Invoke(new Action(() => sendButton.Enabled = true));
                    var roomTag = message.Split()[2];
                    AddMessage($"You joined to the room {roomTag}");
                    SendRequest("/online");
                }
                else if(message.StartsWith("JOINED"))
                {
                    var username = message.Split()[1];
                    AddMessage($"User {username} joined the room");
                    SendRequest("/online");
                }
                else if (message.StartsWith("LEFT"))
                {
                    var username = message.Split()[1];
                    AddMessage($"User {username} leave the room");
                    SendRequest("/online");
                }
                else if (message.StartsWith("CHNAME"))
                {
                    var oldname = message.Split()[2];
                    var currentName = message.Split()[4];
                    AddMessage($"User {oldname} changed name to {currentName}");
                    SendRequest("/online");
                }
                else if(message.StartsWith("QUIT ACCEPTED"))
                {
                    joinToolStripMenuItem.Enabled = true;
                    leaveRoomToolStripMenuItem.Enabled = false;
                    sendButton.Enabled = false;
                }
                else if (message.StartsWith("CREATE ACCEPTED"))
                {
                    var roomTag = message.Split()[2];
                    AddMessage($"You have created the room with tag {roomTag}");
                }
                else
                {
                    AddMessage(message);
                }
            }
        }

        private void AddMessage(string message)
        {
            chat.Invoke(new Action(() =>
            {
                chat.AppendText(message);
                chat.AppendText(Environment.NewLine);
            }));
        }

        private static (string, string) GetIPAndPort()
        {
            var config = File.ReadLines("./config.txt").ToArray()[0].Split(':');
            return (config[0], config[1]);
        }

        private void joinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Join(client);
            form.Show();
        }

        private void createRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendRequest("/room");
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            var message = textField.Text;
            SendRequest(message);
            AddMessage($"[You]: {message}");
            textField.Clear();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendRequest("/disconnect");
        }

        private void leaveRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendRequest("/quit");
            chat.Clear();
        }

        private void setNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SetName(client);
            form.Show();
        }

        private void SendRequest(string request)
        {
            client.Writer.WriteLineAsync(request);
            client.Writer.FlushAsync();
        }
    }
}