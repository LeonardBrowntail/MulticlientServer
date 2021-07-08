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
1.  The server opens a listener that accepts TCP connection,
2.  When a client is connected:
    - The server will receive a username,
    - The username will be broadcasted,
    - The username and IP will be saved into a hastable, and
    - Create a new thread to handle the client.
3. Handler thread will:
   - Receive data from client,
   - Encode the data into string,
     - If the message contains a message, relay it to every connected client and write it into a log.
     - If the message contains a termination code, disconnect client and remove it from the hashtable.
4. When finished, the server will:
   - Send a termination code,
   - Stop all connection, and
   - Clear the hashtable.

### Client Flow
1.  The user will insert their username and host IP,
2.  Client will try to connect to the intended host,
    - If failed, client will retry to connect for three times,
3.  When connected, client will send the username,
4.  Create a new thread to handle incoming message,
    - Receives data from server,
    - Encode the data to string,
      - If the data contains a message, display the message on the screen.
      - If the data contains a termination code, close the connection and notify the user of the server disconnection.
5.  When the user sends a message:
    - Encode the message into bytes and
    - Send the buffer through the stream.
6. When finished, the client will:
   - Send a termination code,
   - Close the connection, and
   - return to step one. (unless the program is closed)
