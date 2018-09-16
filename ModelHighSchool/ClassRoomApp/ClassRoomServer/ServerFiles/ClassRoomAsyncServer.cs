using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

//Repository
using ClassRoomDB.Tables;
using System.IO;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassRoomServer.ServerFiles
{
    // State object for reading client data asynchronously
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public class ClassRoomAsyncServer
    {
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public ClassRoomAsyncServer()
        {
        }

        public static void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[10240];

            // Establish the local endpoint for the socket.
            // The DNS name of the computer
            // running the listener is "host.contoso.com".
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket. 
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read 
                // more data.
                content = state.sb.ToString();
                if (content.IndexOf("<city>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);
                    // Echo the data back to the client.
                    SendSchoolList(handler, content);
                }
                else
                if (content.IndexOf("<school>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);
                    // Echo the data back to the client.
                    Send(handler, content);
                }
                else
                if (content.IndexOf("<TeacherDiary>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);
                    // Echo the data back to the client.
                    Send(handler, content);
                }
                else
                if (content.IndexOf("<ParentDiary>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);
                    // Echo the data back to the client.
                    Send(handler, content);
                }
                else
                {
                    // Not all data received. Get more.
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }

        private static void SendSchoolList(Socket handler, String data)
        {
            string _value = "";
            using (XmlReader reader = XmlReader.Create(new StringReader(data)))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            Console.WriteLine(reader.Name);
                            break;
                        case XmlNodeType.Text:
                            Console.WriteLine(reader.Value);
                            _value = reader.Value;
                            break;
                        case XmlNodeType.XmlDeclaration:
                        case XmlNodeType.ProcessingInstruction:
                            Console.WriteLine(reader.Name + reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            Console.WriteLine(reader.Value);
                            break;
                        case XmlNodeType.EndElement:
                            Console.WriteLine(reader.Name);
                            break;
                    }
                }
            }
            
            
            SchoolTB _schoolTb = new SchoolTB();
            CitySchools_list _schools = _schoolTb.GetSchoolsInCity(_value);
            

            StringBuilder sb = new StringBuilder();
            StringWriter stream = new StringWriter(sb);
            XmlSerializer x = new System.Xml.Serialization.XmlSerializer(_schools.GetType());
            x.Serialize(stream, _schools);

            

            
           
            byte[] byteData = Encoding.ASCII.GetBytes(stream.ToString());


            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        
        }

        private static void Send(Socket handler, String data)
        {
            List<string> _values = new List<string>();
            using (XmlReader reader = XmlReader.Create(new StringReader(data)))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            Console.WriteLine(reader.Name);
                            break;
                        case XmlNodeType.Text:
                            Console.WriteLine(reader.Value);
                            _values.Add(reader.Value);
                            break;
                        case XmlNodeType.XmlDeclaration:
                        case XmlNodeType.ProcessingInstruction:
                            Console.WriteLine(reader.Name + reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            Console.WriteLine(reader.Value);
                            break;
                        case XmlNodeType.EndElement:
                            Console.WriteLine(reader.Name);
                            break;
                    }
                }
            }
            
            
            SchoolTB _schoolTb = new SchoolTB();
            List<School_row> _schools = _schoolTb.GetSchools(_values[0], _values[1]);
            

            StringBuilder sb = new StringBuilder();
            StringWriter stream = new StringWriter(sb);

            foreach( School_row sr in _schools)
            {
                XmlSerializer x = new System.Xml.Serialization.XmlSerializer(sr.GetType());
                x.Serialize(stream, sr);

                StringReader streamreader = new StringReader(sb.ToString());
                object deserialized = x.Deserialize(streamreader);
                School_row sr1 = (School_row)deserialized;
                //Console.WriteLine();
                
            }
            
            //try
            //{
            //    using (StringWriter stream = new StringWriter(sb))
            //    {
            //        BinaryFormatter bin = new BinaryFormatter();
            //        bin.Serialize(stream, _schools);
            //    }
               
            //}
            //catch (IOException)
            //{
            //}
            

            data = String.Format("<Classroom Id=1  Grade=10  Section=A  >" +
	                            "<Student Id=1  Firstname=Ali  Surname=AlQuiaty  />" +
	                            "<Student Id=2  Firstname=Sayeed  Surname=AlQuiaty  />" +
	                            "<Student Id=3  Firstname=Salam  Surname=AlQuiaty  />" +
	                            "<Student Id=4  Firstname=Minhaj  Surname=Ahmed  />" +
	                            "<Student Id=5  Firstname=Parvez  Surname=Shaik  />" +
                                "</Classroom >");
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(stream.ToString());


            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public static int Main(String[] args)
        {
            StartListening();
            return 0;
        }
    }
}



