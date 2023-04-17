using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Napelem.Connection
{
    public class TCPConnection
    {
        NetworkStream stream;
        TcpClient client;
        IPAddress serverIpAddress = IPAddress.Loopback;
        int port = 12345;
        public TCPConnection()
        {
            // Szerver IP címe és port száma
            

            // Kapcsolódás a szerverhez
            client = new TcpClient();
            client.Connect(serverIpAddress, port);

            
         
            Console.ReadLine();
        }
        public void TCPSendMessage(string message)
        {
            // Üzenet küldése a szervernek
            stream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Üzenet elküldve a szervernek.");
        }
        public void TCPCloseConnection()
        {
            client = new TcpClient();
            client.Connect(serverIpAddress, port);
            stream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes("Close connection");
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Üzenet elküldve a szervernek.");

            stream.Close();
            client.Close();
        }


   
    
    }
}
