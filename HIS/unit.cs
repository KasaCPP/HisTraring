using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                socketSend.Connect(endPoint);
                socketSend.Send(Encoding.UTF8.GetBytes(db));
                //int len = socketSend.Receive(buffer,buffer.Length,0);
                //String recvStr = Encoding.UTF8.GetString(buffer,0,len);
                //return recvStr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //socketSend.Shutdown(SocketShutdown.Both);
                socketSend.Close();
            }
            finally 
            {
                socketSend.Close();
            }
        }
        public static String getService(String db) 
        {
            byte[] bytes = new byte[1024];
            string recvStr = null;
            Connection(db);
            try
            {
                int len = socketSend.Receive(bytes, bytes.Length, 0);
                recvStr = Encoding.UTF8.GetString(bytes, 0, len);
            }
            catch (Exception es) 
            {
                MessageBox.Show("失去服务器连接："+es.Message);
            }
            return recvStr;
        }
    }
}
