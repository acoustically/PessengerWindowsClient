using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using static Pessenger.LogInPage2;

namespace Pessenger
{
  class SocketCommunicator
  {
    internal class Containner
    {
      Socket socket;
      Object data;
      public Containner(Socket socket, Object data)
      {
        this.socket = socket;
        this.data = data;
      }

      public Socket Socket { get => socket; set => socket = value; }
      public Object Data { get => data; set => data = value; }
    }

    public static void ReadSocket(Socket socket, List<Object> data)
    {
      Thread thread = new Thread(ReadSocketCallback);
      thread.Start(new Containner(socket, data));
    }

    private static void ReadSocketCallback(Object containner)
    {
      Socket socket = ((Containner)containner).Socket;
      List<Object> dataContainner = (List<Object>)((Containner)containner).Data;

      List<byte> data = new List<byte>();
      byte[] dataPiece = new byte[1024];
      while (socket.Receive(dataPiece) < 1024)
      {
        data.AddRange(dataPiece);
      }

      dataContainner.Add(Encoding.UTF8.GetString(data.ToArray()));
      MessageBox.Show(Encoding.UTF8.GetString(data.ToArray()));
    }

    public static void WriteSocket(Socket socket, Object data)
    {
      Thread thread = new Thread(WriteSocketCallBack);
      thread.Start(new Containner(socket, data));
    }

    private static void WriteSocketCallBack(Object containner)
    {
      Socket socket = ((Containner)containner).Socket;
      Object data = ((Containner)containner).Data;
      socket.Send(Encoding.UTF8.GetBytes((String)data));
    }

  }
}
