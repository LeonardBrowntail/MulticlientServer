using System;
using System.Net;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class MainProgram : Form
    {
        private Server server = null;
        private Client client = null;
        public string stream = string.Empty;

        public MainProgram()
        {
            InitializeComponent();
            Write("Local address: " + Program.localAddress);
            Write("Please choose program mode in Option -> Behaviour...");
        }

        //Server mode selected
        private void select_server(object sender, EventArgs e)
        {
            //Set server mode button to be checked
            serverCheck.Checked = true;
            //Disable client mode button
            clientCheck.Enabled = false;
            //Enable main button
            serverStart.Enabled = true;
            try
            {
                server = Server.GetInstance();
                server.Main = this;
                Write("Press start to start listening to TCP connections");
            }
            catch (Exception error)
            {
                Write("Error: " + error.Message.ToString());
                Console.WriteLine(e);
            }
        }

        //Client mode selected
        private void select_client(object sender, EventArgs e)
        {
            //Disable server mode button
            serverCheck.Enabled = false;
            //Set client mode button to be checked
            clientCheck.Checked = true;
            //Enable username input
            usernameBox.Enabled = true;
            //Enable Host IP input
            destIPBox.Enabled = true;
            //Enable connect button
            clientConnect.Enabled = true;
            Write("Client mode selected, please input the username and host destination...");
        }

        private void RunClient(object sender, EventArgs e)
        {
            IPAddress ip;
            if (IPAddress.TryParse(destIPBox.Text, out ip))
            {
                try
                {
                    client = Client.GetInstance();
                    client.Main = this;
                    client.Start();
                    client.Connect(ip, usernameBox.Text);
                    Write("");
                }
                catch (Exception error)
                {
                    Write("Error: " + error.ToString());
                    Console.WriteLine(error);
                }
                if (Program.running)
                {
                    clientConnect.Enabled = false;
                    clientDisconnect.Enabled = true;
                    inputBox.Enabled = true;
                    sendButton.Enabled = true;
                }
            }
            else
            {
                destIPBox.Text = "";
                Write("Invalid host address, please input a valid address...");
            }
        }

        private void RunServer(object sender, EventArgs e)
        {
            server.Start();
            if (Program.running)
            {
                serverStart.Enabled = false;
                serverStop.Enabled = true;
            }
        }

        private void StopClient(object sender, EventArgs e)
        {
            client.Stop();
            if (!Program.running)
            {
                clientConnect.Enabled = true;
                clientDisconnect.Enabled = false;
                inputBox.Enabled = false;
                sendButton.Enabled = false;
            }
        }

        private void StopServer(object sender, EventArgs e)
        {
            server.Stop();
            if (!Program.running)
            {
                serverStart.Enabled = true;
                serverStop.Enabled = false;
            }
        }

        private void SendMessage(object sender, EventArgs e)
        {
            client.Send(inputBox.Text);
            inputBox.Text = "";
        }

        public void Write(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => Write(message)));
            }
            else
            {
                chatBox.Text += message + Environment.NewLine;
            }
        }
    }
}