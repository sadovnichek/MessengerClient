using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessengerUI
{
    public partial class SetName : Form
    {
        private Client client;

        public SetName(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void button_Click(object sender, EventArgs e)
        {
            client.Writer.WriteLine($"/name {nameField.Text}");
            client.Writer.Flush();
            this.Close();
        }
    }
}
