using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Form1 : Form
    {
        Socket client;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            client.Connect(ipe);
            byte[] data;
            data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add("server:" + Encoding.ASCII.GetString(data));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data;
            data = Encoding.ASCII.GetBytes(textBox2.Text);
            client.Send(data);
            listBox1.Items.Add("client:" + textBox2.Text);
            data = new byte[1024];

            client.Receive(data);
            listBox1.Items.Add("server:" + Encoding.ASCII.GetString(data));
        }
    }
}
