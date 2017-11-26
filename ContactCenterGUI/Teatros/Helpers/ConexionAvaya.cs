using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterGUI.Teatros.Helpers
{
    public delegate void LineReceive(ConexionAvaya sender, string data);
    public class ConexionAvaya
    {
        private static readonly Object obj = new Object();
        private readonly int READ_BUFFER_SIZE;
        public event LineReceive LineReceived;
        private TcpClient client;
        private byte[] readBuffer;
        private string m_telefonoCliente;
        private string m_telefonoCentral;
        public string TelefonoCentral
        {
            get { return m_telefonoCentral; }
            set { m_telefonoCentral = value; }
        }

        public string TelefonoCliente
        {
            get { return m_telefonoCliente; }
            set { m_telefonoCliente = value; }
        }

        public ConexionAvaya(TcpClient client)
        {
            int bufferSize = Convert.ToInt32(ConfigurationManager.AppSettings["Buffer"]);
            READ_BUFFER_SIZE = bufferSize;
            readBuffer = new byte[(bufferSize - 1)];
            this.client = client;
            this.client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(this.StreamReceiver), null);
        }
        private void StreamReceiver(IAsyncResult ar)
        {
            int BytesRead;
            string mensaje;
            try
            {
                lock (obj)
                {
                    //  Ensure that no other threads try to use the stream at the same time.
                    client.GetStream();
                    //  Finish asynchronous read into readBuffer and get number of bytes read.
                    BytesRead = client.GetStream().EndRead(ar);
                }


                if ((BytesRead <= READ_BUFFER_SIZE))
                {
                    //  Convert the byte array the message was saved into
                    mensaje = Encoding.ASCII.GetString(readBuffer, 0, BytesRead);
                    if (LineReceived != null)
                    {
                        LineReceived(this, mensaje.Trim());
                    }
                    lock (obj)
                    {
                        //  Ensure that no other threads try to use the stream at the same time.
                        client.GetStream();
                        //  Start a new asynchronous read into readBuffer.
                        client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE,new AsyncCallback(this.StreamReceiver), null);
                    }
                }
                else if (BytesRead == 0)
                {
                   // string ip = client.Client.RemoteEndPoint.ToString().Split(":"c)
                }
            }
            catch (IOException ex)
            {
            }
            catch (InvalidOperationException ex)
            {

            }
            catch (Exception ex)
            {
                client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(this.StreamReceiver), null);
            }
        }
    }
}
