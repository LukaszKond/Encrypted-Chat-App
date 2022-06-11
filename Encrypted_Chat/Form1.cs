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
using System.Security.Cryptography;

namespace Encrypted_Chat
{
    public partial class Form1 : Form
    {
        public StreamReader reader;
        public StreamWriter writer;
        public string received;
        
        public string toSend;
        public string fileToSend;
        TcpListener server = null;
        TcpClient client = null;
        EncryptionManager encryptionManager = null;
        SessionData session = new SessionData();
        public int messageLen;
        byte[] receivedEnc;

        private const string defaultSelectedFileText = "No file selected";

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

            encryptionManager = new EncryptionManager();
            var result = encryptionManager.GenerateKeys(txtNazwa.Text, txtPassword.Text);
            if (result == false) { this.Close(); }


            try // connect to server
            {
                client = new TcpClient();
                client.Connect(ip, port);               

                txtStatus.Text +=  "CONNECTED TO PARTNER \r\n";
                reader = new StreamReader(client.GetStream());
                writer = new StreamWriter(client.GetStream());

                //exchange public keys
                encryptionManager.partner_publicKey = session.GetPublicKey(client, encryptionManager._publicKey.Length);

                session.GenerateSessionKey();


                using var rsa = new RSACryptoServiceProvider(2048);
                rsa.ImportRSAPublicKey(encryptionManager.partner_publicKey, out var _);

                writer.WriteLine(Convert.ToBase64String(rsa.Encrypt(session.key, RSAEncryptionPadding.Pkcs1)));
                writer.WriteLine(Convert.ToBase64String(rsa.Encrypt(session.iv, RSAEncryptionPadding.Pkcs1)));



            }
            catch (Exception ex) //become server
            {
                txtStatus.Text += "PARTNER NOT HOSTING, STARTING THE SERVER \r\n";
                server = new TcpListener(ip, port);
                server.Start();
                while (true)
                {
                    client = server.AcceptTcpClient();
                    if (client != null) { break; }
                }
                reader = new StreamReader(client.GetStream());
                writer = new StreamWriter(client.GetStream());
                //exchange public keys



                session.SendPublicKey(client, encryptionManager._publicKey);

                using var rsa = new RSACryptoServiceProvider(2048);
                rsa.ImportRSAPrivateKey(encryptionManager._privateKey, out var _);

                session.key  = Convert.FromBase64String(reader.ReadLine());
                session.iv = Convert.FromBase64String(reader.ReadLine());
                session.key = rsa.Decrypt(session.key, RSAEncryptionPadding.Pkcs1);
                session.iv = rsa.Decrypt(session.iv, RSAEncryptionPadding.Pkcs1);

                


            }
            encryptionManager.session_iv = session.iv;
            encryptionManager.session_key = session.key;
            writer.AutoFlush = true;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;
        }

        

        private void Sendbutton_Click(object sender, EventArgs e)
        {

            if (txtMessage.Text != "")
            {
                toSend = txtMessage.Text;               
                backgroundWorker2.RunWorkerAsync();
            }

            if (selectedFile.Text != defaultSelectedFileText && selectedFile.Text != "")
            {
                fileToSend = selectedFile.Text;               
                backgroundWorker3.RunWorkerAsync();
            }

            selectedFile.Text = defaultSelectedFileText;
            txtMessage.Text = "";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    received = reader.ReadLine();
                    var byteTab2 = Convert.FromBase64String(received);
                    if (radioECB.Checked)
                    {
                        received = encryptionManager.decryptECB(byteTab2);
                    }
                    else
                    {
                        received = encryptionManager.decryptCBC(byteTab2);
                    }
                    this.txtStatus.Invoke(new MethodInvoker(delegate ()
                    {
                        txtStatus.Text += ("[Partner] : " + received + "\r\n");
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. Please check if you are using same encryption mode as your partner");
                    //MessageBox.Show("You are using different encryption modes with your partner!");
                }
            }
        }


        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                byte[] byteTab;
                if (radioECB.Checked)
                {
                    byteTab = encryptionManager.encryptECB(toSend);
                }
                else
                {
                    byteTab = encryptionManager.encryptCBC(toSend);
                }
                var toSend2 = Convert.ToBase64String(byteTab);
                writer.WriteLine(toSend2);

                this.txtStatus.Invoke(new MethodInvoker(delegate ()
                {
                    txtStatus.Text += ("[Me]  : " + toSend + "\r\n");
                }));
            }
            else
            {
                MessageBox.Show("error");
            }
            backgroundWorker2.CancelAsync();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                var cipher = radioECB.Checked ? CipherMode.ECB : CipherMode.CBC;
                encryptAndSendFile(cipher);
            }
            else
            {
                MessageBox.Show("error");
            }
            backgroundWorker3.CancelAsync();
        }

        private void encryptAndSendFile(CipherMode cipher)
        {

            string encryptedFilePath = "";
            try
            {
                new Thread(updateProgressBar).Start();
                encryptedFilePath = encryptionManager.encryptFile(fileToSend, cipher);


                // at the end delete file
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }       
        }

        private void updateProgressBar()
        {
            FileProgressBar.Minimum = 0;
            FileProgressBar.Maximum = 100;
            while (true)
            {
                Thread.Sleep(100);
                FileProgressBar.Invoke(new MethodInvoker(delegate ()
                {
                    FileProgressBar.Value = (int) (encryptionManager.getEncryptionProgress() * 100);
                }));
                if (encryptionManager.getEncryptionProgress() >= 1) return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select File";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter += "";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                selectedFile.Text = openFileDialog1.FileName;
            }
            else
            {
                selectedFile.Text = defaultSelectedFileText;
            }
        }

        private void selectedFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioECB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void FileProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void EncTypeBox_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
