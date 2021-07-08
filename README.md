# Multi Client Server
  This is a simple chatting program written in C# with standard libraries, such as System.Net and System.Threading with the addition of logging. Made as a final project for my 4th semester.

## Description
So, basically, I had to make a program for my college and this is what I come up with. There were three major things that the program should do, which are:
1.  The program must be able to connect multiple clients with the server doing the broadcasting,
2.  The program must use different threads to handle each connected clients, and
3.  The program must be able to log the events and information that happened while the server is runnning.

## How To Use
  Run the program then choose between client mode or server mode.
### Server Mode
  After selecting server mode, the user can press the start button on the UI. Once started, the server will run and be able to receive connection. As long as the server is runnning, the server will relay and record every message sent by every client. When the the program is no longer in use, user can turn off the server by simply pressing the stop button or closing the program.
### Client Mode
  After selecting client mode, the user can input their username and their destination IP. The program will try to parse the IP input and connect to the server. While connected, the user can chat with everyone connected on the server. The user can send messages to the server and receive messages from others. User will also be notified if someone left the server or if the server is shutting down. Once finished, the user can then disconnect from the server manually by pressing the disconnect button or by closing the program.

## Program Flow
  I will explain how the server and the client works here.
![image](https://user-images.githubusercontent.com/63572694/124799956-4cf69080-df7f-11eb-8e2e-93658d99b491.png)
### Server Flow
  First, the server opens a listener that accepts TCP connections. When a client is connected, the server will receive the client's username and broadcasts it to every connected clients. The server then stores the username and IP into a hastable. The server then creates a new thread to handle the new client.
  The thread job is to accept messages from the handled client. When a message is received, the program will encode it into a string and reads the content. If the content is a message, then the server will relay the message to every connected clients, including the handled client. The message will then be logged into a file. If the content is a termination code, the server will broadcast the disconnection of the handled client then proceeds to remove the client from the hastable. The thread is finished and the client is disconnected.
  When the program is finished, the user can close the program. The server will broadcast a termination code to every connected client before cloing all connection.
### Client Flow 
  First, the user can insert its username and host IP. The program will try to connect to the intended server and if it is unsuccessful, the program will retry the connection for three times. If the client is connected, the program will send its username and starts a new thread.
  Same as the server, this thread job is to handle incoming data and showing the message it on the screen. If the message contains a terminator code, the program will notify the user that the server has disconnected. The thread will run while the program is connected to the server.
  When sending a message, it will be encoded into bytes and sent through a network stream to the server.
