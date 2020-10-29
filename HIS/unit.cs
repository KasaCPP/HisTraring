using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HIS
{
    public static class unit
    {
        private static readonly string address = "localhost";
        private static readonly int port = 9001;
        private static Socket socketSend = null;
        private static byte[] buffer = new byte[1024 * 1024 * 2];
        public static void Connection(String db) 
        {
            try
            {
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(address);
                IPEndPoint endPoint = new IPEndPoint(ip, port);
                socketSend.Receive(buffer);
                socketSend.Connect(endPoint);
                socketSend.Send(Encoding.UTF8.GetBytes(db));
            }
            catch (Exception ex)
            {
                socketSend.Shutdown(SocketShutdown.Both);
                socketSend.Close();
                
            }
            finally 
            {
                socketSend.Close();
            }
        }
    }
}
