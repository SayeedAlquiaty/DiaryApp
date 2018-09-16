using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiaryApp.Model
{
    // State object for receiving data from remote device.
public class StateObject {
    // Client socket.
    public Socket workSocket = null;
    // Size of receive buffer.
    public const int BufferSize = 10240;
    // Receive buffer.
    public byte[] buffer = new byte[BufferSize];
    // Received data string.
    public StringBuilder sb = new StringBuilder();
}

public class ServerConnector
{
    // The port number for the remote device.
    private const int port = 11000;

    // ManualResetEvent instances signal completion.
    private static ManualResetEvent connectDone = 
        new ManualResetEvent(false);
    private static ManualResetEvent sendDone = 
        new ManualResetEvent(false);
    private static ManualResetEvent receiveDone = 
        new ManualResetEvent(false);

    //Host Address Info
    public static  IPHostEntry IPHostInfo { get; set; }
    public static IPAddress HostIPAddress { get; set; }
    public static IPEndPoint RemoteEP { get; set; }

    //Socket
    public static Socket Client { get; set; }

    // The response from the remote device.
    private static String response = String.Empty;

    private static void StartClient() {
        // Connect to a remote device.
        try {
            // Establish the remote endpoint for the socket.
            // The name of the 
            // remote device is "host.contoso.com".
            IPHostInfo = Dns.Resolve("192.168.0.7");
            HostIPAddress = IPHostInfo.AddressList[0];
            RemoteEP = new IPEndPoint(HostIPAddress, port);

            // Create a TCP/IP socket.
            Client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.
            Client.BeginConnect( RemoteEP, 
                new AsyncCallback(ConnectCallback), Client);
            connectDone.WaitOne();

            
            
        } catch (Exception e) {
            System.Windows.MessageBox.Show(e.ToString());
        }
    }

    private static void ConnectCallback(IAsyncResult ar) {
        try {
            // Retrieve the socket from the state object.
            Socket client = (Socket) ar.AsyncState;

            // Complete the connection.
            client.EndConnect(ar);

            System.Windows.MessageBox.Show("Socket connected to {0}",
                client.RemoteEndPoint.ToString());

            // Signal that the connection has been made.
            connectDone.Set();
        } catch (Exception e) {
            System.Windows.MessageBox.Show(e.ToString());
        }
    }

    private static void Receive(Socket client) {
        try {
            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = client;

            // Begin receiving the data from the remote device.
            client.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReceiveCallback), state);
        } catch (Exception e) {
            System.Windows.MessageBox.Show(e.ToString());
        }
    }

    private static void ReceiveCallback( IAsyncResult ar ) {
        try {
            // Retrieve the state object and the client socket 
            // from the asynchronous state object.
            StateObject state = (StateObject) ar.AsyncState;
            Socket client = state.workSocket;

            // Read data from the remote device.
            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0) {
                // There might be more data, so store the data received so far.
            state.sb.Append(Encoding.ASCII.GetString(state.buffer,0,bytesRead));

                // Get the rest of the data.
                client.BeginReceive(state.buffer,0,StateObject.BufferSize,0,
                    new AsyncCallback(ReceiveCallback), state);
            } else {
                // All the data has arrived; put it in response.
                if (state.sb.Length > 1) {
                    response = state.sb.ToString();
                }
                // Signal that all bytes have been received.
                receiveDone.Set();
            }
        } catch (Exception e) {
            System.Windows.MessageBox.Show(e.ToString());
        }
    }

    private static void Send(Socket client, String data) {
        // Convert the string data to byte data using ASCII encoding.
        byte[] byteData = Encoding.ASCII.GetBytes(data);

        // Begin sending the data to the remote device.
        client.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), client);
    }

    private static void SendCallback(IAsyncResult ar) {
        try {
            // Retrieve the socket from the state object.
            Socket client = (Socket) ar.AsyncState;

            // Complete sending the data to the remote device.
            int bytesSent = client.EndSend(ar);
            System.Windows.MessageBox.Show(String.Format("Sent {0} bytes to server.", bytesSent));

            // Signal that all bytes have been sent.
            sendDone.Set();
        } catch (Exception e) {
            System.Windows.MessageBox.Show(e.ToString());
        }
    }
    public void TeacherDiary()
    {
        // Send test data to the remote device.
        Send(Client, "<xml><school><name>MSCreative</name><city>HYD</city></school></xml>");
        sendDone.WaitOne();
        

        // Receive the response from the remote device.
        Receive(Client);
        receiveDone.WaitOne();

        // Write the response to the console.
        System.Windows.MessageBox.Show(String.Format("Response received : {0}", response));

        // Release the socket.
        Client.Shutdown(SocketShutdown.Both);
        Client.Close();
    }
    public ServerConnector()
    {
        StartClient();
    }
   }
}
