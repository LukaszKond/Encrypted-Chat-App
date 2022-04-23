using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSK_Chat
{
    public partial class Form1 : Form
    {
        public StreamReader reader;
        public StreamWriter writer;
        public string received;
        public string toSend;
        TcpListener server = null;
        TcpClient client = null;
        

        public Form1()
        {
            InitializeComponent();            
        }       

        private void Form1_Load(object sender, EventArgs e)
        {

        } 

        private void btnStart_Click(object sender, EventArgs e)
        {            
            IPAddress ip = IPAddress.Parse(txtAddress.Text);
            int port = Convert.ToInt32(txtPort.Text);
            
            try
            {
                client = new TcpClient();
                client.Connect(ip, port);
                txtStatus.Text += "CONNECTED TO PARTNER \r\n";
                reader = new StreamReader(client.GetStream());
                writer = new StreamWriter(client.GetStream());
                writer.AutoFlush = true;
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.WorkerSupportsCancellation = true;
            }
            catch (Exception ex)
            {
                txtStatus.Text += "PARTNER NOT HOSTING, STARTING THE SERVER \r\n";
                server = new TcpListener(ip, port);
                server.Start();
                while (true)
                {
                    client = server.AcceptTcpClient();
                    reader = new StreamReader(client.GetStream());
                    writer = new StreamWriter(client.GetStream());
                    writer.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();
                    backgroundWorker2.WorkerSupportsCancellation = true;
                    if (client != null) { break; }
                }
            }       
        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {

            if (txtMessage.Text != "")
            {
                toSend = txtMessage.Text;
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(client.Connected)
            {
                try
                {
                    received = reader.ReadLine();
                    this.txtStatus.Invoke(new MethodInvoker(delegate ()
                    {
                        txtStatus.Text+=("Partner : " + received + "\r\n");
                    }));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if(client.Connected)
            {
                writer.WriteLine(toSend);
                
                this.txtStatus.Invoke(new MethodInvoker(delegate ()
                {
                    txtStatus.Text+=("Me : " + toSend + "\r\n");
                }));
            }
            else
            {
                MessageBox.Show("error");
            }
            backgroundWorker2.CancelAsync();
        }

    }
}
