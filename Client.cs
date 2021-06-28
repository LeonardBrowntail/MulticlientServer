using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FinalProject
{
    internal class Client
    {
        private static Client instance = new Client();
        private const short port = 8888;
        private MainProgram main = null;
        private TcpClient client;
        private string data;

        public MainProgram Main { get => main; set => main = value; }

        private Client()
        {
            client = default(TcpClient);
        }

        public void Connect(IPAddress ip, string username)
        {
            try
            {
                //Connect to host
                client = new TcpClient(ip.ToString(), port);
                Write("Connected!");

                //Get Stream and send the username
                var stream = client.GetStream();
                stream = client.GetStream();
                var buffer = Encoding.ASCII.GetBytes(username + "</usr>");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();

                Thread clientThread = new Thread(GetMessage);
                clientThread.Start();
            }
            catch (Exception e)
            {
                Write("Error: " + e.Message);
                Console.WriteLine(e);
                client.Close();
            }
        }

        private void GetMessage()
        {
            try
            {
                while (Program.running)
                {
                    var stream = client.GetStream();
                    var size = client.ReceiveBufferSize;

                    byte[] buffer = new byte[size];
                    stream.Read(buffer, 0, size);
                    data = Encoding.ASCII.GetString(buffer);
                    Write(data);
                }
            }
            catch (Exception e)
            {
                Write("Error: " + e.Message);
                Console.WriteLine(e);
            }
            client.Close();
        }

        public static Client GetInstance()
        {
            return instance;
        }

        private void Write(string message)
        {
            main.Write(message);
        }

        public void Send(string message)
        {
            try
            {
                var stream = client.GetStream();
                var buffer = Encoding.ASCII.GetBytes(message + "</msg>");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
            catch (Exception e)
            {
                Write("Error: " + e.Message);
                Console.WriteLine(e);
            }
        }

        public void Start()
        {
            Program.running = true;
        }

        public void Stop()
        {
            Program.running = false;
        }
    }
}