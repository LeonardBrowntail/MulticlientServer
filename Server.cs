using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FinalProject
{
    /* Logger class to handle server logging */

    public static class Logger
    {
        private static readonly object _log_lock = new object();

        public static void Log(string message)
        {
            lock (_log_lock)
            {
                using (StreamWriter stream = File.AppendText(Program.path))
                {
                    stream.WriteLineAsync(message);
                }
            }
        }

        public static void LogStart()
        {
            using (StreamWriter stream = File.CreateText(Program.path))
            {
                stream.WriteLine("Log " + DateTime.Now.ToString());
            }
        }
    }

    internal class Server
    {
        // Lock for thread safety
        private static readonly object _lock = new object();

        // Connected client list
        public static Hashtable clientList;

        // The count of connected clients
        public static int ClientCount;

        // Server instance
        private static Server instance = new Server();

        // Client listener
        private TcpListener server;

        // Main reference
        private MainProgram main;

        public MainProgram Main { get => main; set => main = value; }

        // Create a server with local addresss
        private Server()
        {
            server = new TcpListener(IPAddress.Parse(Program.localAddress), 8888);
            ClientCount = 0;
            clientList = new Hashtable();
        }

        private void Listen()
        {
            try
            {
                Write("Server started [ " + server.LocalEndpoint.ToString() + " ]");
                TcpClient client = default(TcpClient);
                while (Program.running)
                {
                    //Perform blocking call and wait for connection
                    if (server.Pending())
                    {
                        Write("Waiting for connection...");
                        client = server.AcceptTcpClient();
                        Write("Client connected...");

                        /* This part is to retrieve the username */
                        // Get incoming stream from client
                        NetworkStream stream = client.GetStream();
                        int bufferSize = client.ReceiveBufferSize;
                        byte[] buffer = new byte[bufferSize];
                        Write("Buffer size = " + bufferSize);
                        string username = string.Empty;
                        // Read the stream and store data into buffer
                        stream.Read(buffer, 0, bufferSize);
                        // Turn the block of data into string
                        username = Encoding.ASCII.GetString(buffer);
                        // Cut the terminator
                        username = username.Substring(0, username.IndexOf("</usr>"));
                        // Show data in chatlog
                        Write(username + " [" + client.Client.RemoteEndPoint.ToString() + "] connected!");

                        /* Insert the new client into a hashtable */
                        // Using mutex to stop other threads from accessing it
                        lock (_lock) clientList.Add(username, client);
                        Write(username + " has been added into the client list");

                        /* Inform clients about the new client */
                        Broadcast(username + " has joined the chat!", null, false);
                        /* This part is the multithreading part where clients would be handled by separate threads */
                        // Create a new thread
                        Thread clientHandler = new Thread(() => ClientHandle(username));
                        Write("ClientHandler for " + username + " created, starting...");
                        clientHandler.Start();
                        Write("Client handled");
                        ClientCount++;
                    }
                }
                client.Close();
                server.Stop();
                clientList.Clear();
            }
            catch (Exception e)
            {
                Write("Error :" + e.Message.ToString());
                Console.WriteLine(e);
            }
        }

        /* This function would broadcast a message to every client connected to the server */

        public static void Broadcast(string message, string username, bool talking)
        {
            // Using mutex to avoid access from other threads
            lock (_lock)
            {
                foreach (DictionaryEntry item in clientList)
                {
                    // Make a client with the socket saved in dictionary
                    TcpClient destClient = (TcpClient)item.Value;
                    // Create a network stream to send data through
                    NetworkStream stream = destClient.GetStream();
                    // Create a buffer to store data
                    byte[] buffer = new byte[8192];

                    //If the data sent is a chat
                    if (talking)
                    {
                        buffer = Encoding.ASCII.GetBytes(username + ": " + message);
                    }
                    //If the data sent is a status update
                    else
                    {
                        buffer = Encoding.ASCII.GetBytes(message);
                    }
                    // Write the data into the stream
                    stream.Write(buffer, 0, buffer.Length);
                    // Flush the stream
                    stream.Flush();
                }
            }
        }

        /* This function would handle the clients */

        private void ClientHandle(string usr)
        {
            TcpClient client;
            //Lock so no other threads can access the list at the same time
            lock (_lock)
            {
                client = (TcpClient)clientList[usr];
            }

            if (client != null)
            {
                while (client.Connected)
                {
                    try
                    {
                        //Getting stream from client
                        var stream = client.GetStream();
                        int size = client.ReceiveBufferSize;
                        byte[] buffer = new byte[size];
                        //Reading the buffer and saving the length into an int
                        int data = stream.Read(buffer, 0, size);
                        //Convert the data block into string
                        string str = Encoding.ASCII.GetString(buffer);
                        //Read the string until terminator
                        str = str.Substring(0, str.IndexOf("</msg>"));
                        //Broadcast the data to every client
                        Broadcast(str, usr, true);
                    }
                    catch (Exception e)
                    {
                        Write("Error: " + e.Message);
                        Console.WriteLine(e);
                    }
                }
                Write("Client Disconnected");
            }
            client.Close();
        }

        public static Server GetInstance()
        {
            return instance;
        }

        private void Write(string message)
        {
            main.Write(message);
            Logger.Log(message);
        }

        public void Start()
        {
            Program.running = true;
            server.Start();
            Logger.LogStart();
            Thread serverThread = new Thread(Listen);
            serverThread.Start();
        }

        public void Stop()
        {
            Program.running = false;
        }
    }
}