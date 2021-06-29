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

        public MainProgram Main { get => main; set => main = value; }

        private Client()
        {
            client = default(TcpClient);
        }

        public void Connect(IPAddress ip, string username)
        {
            for (short r = 0; r < 3; r++)
            {
                try
                {
                    // Connect to host
                    client = new TcpClient(ip.ToString(), port);
                    Write("Connected!");
                    Program.running = true;
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);
                }
            }
            if (client != null)
            {
                if (client.Connected)
                {
                    try
                    {
                        // Get Stream and send the username
                        var stream = client.GetStream();
                        stream = client.GetStream();
                        var buffer = Encoding.ASCII.GetBytes(username + "</usr>");
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();

                        // Create a thread to handle incoming messages
                        Thread clientThread = new Thread(GetMessage);
                        clientThread.Start();

                        // A Thread to ping the client, needed to refresh client.Connected
                        Thread keepAlive = new Thread(KeepAlive);
                        keepAlive.Start();
                    }
                    catch (Exception e)
                    {
                        Write(e.Message);
                        Console.WriteLine(e);
                    }
                }
            }
            else
            {
                Write("Unable to connect to " + ip.ToString() + " after 3 retries...");
            }
        }

        private void GetMessage()
        {
            try
            {
                while (client.Connected)
                {
                    var stream = client.GetStream();
                    var size = client.ReceiveBufferSize;
                    var buffer = new byte[size];
                    try
                    {
                        stream.Read(buffer, 0, size);
                    }
                    catch { }
                    var str = Encoding.ASCII.GetString(buffer);
                    if (str.Contains("<stop>"))
                    {
                        Write("Server has been shut down");
                    }
                    else
                    {
                        Write(str);
                    }
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                Write(e.Message);
                Console.WriteLine(e);
            }
        }

        public static Client GetInstance()
        {
            return instance;
        }

        private void Write(string message)
        {
            main.Write(Environment.NewLine + message);
        }

        public void Send(string message)
        {
            if (client != null)
            {
                if (client.Connected)
                {
                    try
                    {
                        var stream = client.GetStream();
                        var buffer = Encoding.ASCII.GetBytes(message + "</msg>");
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();
                        stream.Close();
                    }
                    catch (Exception e)
                    {
                        Write(e.Message);
                        Console.WriteLine(e);
                    }
                }
            }
        }

        public void Stop()
        {
            Program.running = false;
            Send("<stop>");
            Write("Disconnected from server...");
            client.Close();
        }

        private void KeepAlive()
        {
            while (client.Connected)
            {
                Thread.Sleep(1000);
            }
        }
    }
}