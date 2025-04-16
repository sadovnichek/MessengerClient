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

        private async Task ReceiveMessageAsync(Client client)
        {
            while (true)
            {
                var message = await client.Reader.ReadLineAsync();
                if (string.IsNullOrEmpty(message))
                    continue;
                else if (message == "DISCONNECT ACCEPTED")
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
                    break;
                }
                else if (message.StartsWith("NAME ACCEPTED"))
                {
                    MessageBox.Show(message);
                }
                else if (message.StartsWith("QUIT ACCEPTED"))
                {
                    joinToolStripMenuItem.Enabled = true;
                    leaveRoomToolStripMenuItem.Enabled = false;
                    sendButton.Invoke(new Action(() => sendButton.Enabled = false));
                    onlineUsers.Invoke(new Action(onlineUsers.Items.Clear));
                    chat.Invoke(new Action(chat.Clear));
                    textField.Invoke(new Action(textField.Clear));
                }
                else if(message.StartsWith("ONLINE"))
                {
                    onlineUsers.Invoke(() =>
                    {
                        onlineUsers.Items.Clear();
                        message.Split()[1].Split(';').ToList().ForEach(p => onlineUsers.Items.Add(p));
                    });
                }
                else if (message.StartsWith("JOIN ACCEPTED"))
                {
                    joinToolStripMenuItem.Enabled = false;
                    leaveRoomToolStripMenuItem.Enabled = true;
                    sendButton.Invoke(new Action(() => sendButton.Enabled = true));
                    RequestOnlineUsers();
                }
                else if(message.StartsWith("JOINED") || message.StartsWith("LEFT") || message.StartsWith("CHNAME"))
                {
                    RequestOnlineUsers();
                }
                else if(message.StartsWith("QUIT ACCEPTED"))
                {
                    joinToolStripMenuItem.Enabled = true;
                    leaveRoomToolStripMenuItem.Enabled = false;
                    sendButton.Enabled = false;
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
            var form = new JoinForm(client);
            form.Show();
        }

        private void createRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.Writer.WriteLineAsync("/room");
            client.Writer.FlushAsync();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            var message = textField.Text;
            client.Writer.WriteLineAsync(message);
            client.Writer.FlushAsync();
            AddMessage($"[You]: {message}");
            textField.Clear();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.Writer.WriteLineAsync("/disconnect");
            client.Writer.FlushAsync();
        }

        private void leaveRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.Writer.WriteLineAsync("/quit");
            client.Writer.FlushAsync();
            chat.Clear();
        }

        private void setNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new NameForm(client);
            form.Show();
        }

        private void RequestOnlineUsers()
        {
            client.Writer.WriteLineAsync("/online");
            client.Writer.FlushAsync();
        }
    }
}
