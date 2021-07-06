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
  After selecting server mode, the user can press the start button on the UI. After pressing it, the server will run and be able to receive connection. As long as the server is runnning, the server will relay and record every message sent by every client. When the the program is no longer in use, user can turn off the server by simply pressing the stop button or closing the program.
### Client Mode
  After selecting client mode, the user can input their username and their destination IP. The program will try to parse the IP input and connect to the . If the program failed at connecting, it will retry three times with the interval of a second. After connected, the user can now chat with everyone connected on the server. After we finish, we can then use disconnect from the server manually by pressing the disconnect server or by closing the program.

## Program Flow
  I will explain how the server and the client works here.
### Server Flow
  First off, the server opens a listener that accepts TCP connections. Client will then connect to the server and sends its' username, in which the server will receive and The server broadcasts the recently connected client to every existing clients in the list of connected clients. The server then adds the recently connected client into the client and then be "forwarded" to a thread that handles it. The server then continues to listen new incoming connection. When the server received a buffer sent by a client, it will specify it as a string and detects the codes that is contained inside. If the code is a stop code, the program will know that the client is disconnected. If it is a message code, the message will then be encoded back to bytes and relayed to all connected clients. When the server is closed by the user, it will send a code that will notify every client connected that the server is shutting down.
### Client Flow 
  When the user pressed connects, the program will create a new client that connects to the server using the specified IP. When connected, the program will send user's username and then it will enter a thread which handles incoming messages from the server. The message handler receives data from the server and encodes it into string. When the client sends a message, the message will be encoded into bytes and be sent through a network stream, which will then get relayed by the server to all connected clients. When the client disconnects, the client will send a code as string that will be received by the server as an indication that the client is disconnecting. Same goes with the server, if the client receives a stop code, the program will then know that the server is disconnecting.
